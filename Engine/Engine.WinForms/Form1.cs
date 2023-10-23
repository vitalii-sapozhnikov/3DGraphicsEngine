﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Engine.WinForms
{
    public partial class Form1 : Form
    {
        private string _cubePath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName + @"\Files\cube.off";

        private List<Vector3> vertices;
        private List<Face> faces;
        private List<(int, int)> verticesIndLines;

        private Point[] points;

        private Vector3 cameraPosition;
        private Vector3 cameraTarget;
        private Vector3 upVector;

        private Vector3 objectRotation;

        private Vector3[] facesNormal;

        private float nearPlaneDistance = 1;
        private float farPlaneDistance = 100;
        private float fieldOfView = 45;
        private float aspectRatio = 1;

        private float[,] zLevel;
        private float[] pointsZLevel;
        private float[] backfacePointsZLevel;

        private int fps;

        private Bitmap texture;

        private Color fogColor = Color.Gray;

        private bool[] transparentFaces;

        public Form1()
        {
            InitializeComponent();

            texture = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(texture);
            g.Clear(Color.Black);
            textureView.Image = texture;
            Bitmap fogColorBitmap = new Bitmap(50, 50);
            g = Graphics.FromImage(fogColorBitmap);
            g.Clear(fogColor);
            fogColorView.Image = fogColorBitmap;

            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.raster_MouseWheel);

            //loadFile(mushroomPath, "mushroom_triang.off");
            //loadFile(teapotPath, "teapot.off");
            loadFile(_cubePath, "cube.off");
        }

        private void CalculatePoints()
        {
            zLevel = new float[raster.Width, raster.Height];
            for (int i = 0; i < raster.Width; i++)
            {
                for (int j = 0; j < raster.Height; j++)
                    zLevel[i, j] = float.MaxValue;
            }
            aspectRatio = (float)raster.Width / raster.Height;
            pointsZLevel = new float[vertices.Count];
            backfacePointsZLevel = new float[vertices.Count];
            points = new Point[vertices.Count];
            Matrix4x4 LookAt = Matrix4x4.CreateLookAt(cameraPosition, cameraTarget, upVector);
            Matrix4x4 Perspective = Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView * 0.0174532925f, aspectRatio, nearPlaneDistance, farPlaneDistance);
            Matrix4x4 RotateX = Matrix4x4.CreateRotationX(objectRotation.X * 0.0174532925f);
            Matrix4x4 RotateY = Matrix4x4.CreateRotationY(objectRotation.Y * 0.0174532925f);
            Matrix4x4 RotateZ = Matrix4x4.CreateRotationZ(objectRotation.Z * 0.0174532925f);
            Matrix4x4 Rotate = RotateZ * RotateY * RotateX;
            float minZLevel = float.MaxValue;
            float maxZLevel = float.MinValue;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vector4 vr = MultiplyVector(Rotate, new Vector4(vertices[i], 1));
                Vector4 vlook = MultiplyVector(LookAt, vr);
                Vector4 v = MultiplyVector(Perspective, vlook);
                v = v / v.W;

                Point p = new Point
                {
                    X = (int)(v.X * raster.Width + raster.Width / 2),
                    Y = (int)(v.Y * raster.Height + raster.Height / 2)
                };
                pointsZLevel[i] = v.Z * (farPlaneDistance - nearPlaneDistance);
                backfacePointsZLevel[i] = pointsZLevel[i];
                if (pointsZLevel[i] > maxZLevel)
                    maxZLevel = pointsZLevel[i];
                if (pointsZLevel[i] < minZLevel)
                    minZLevel = pointsZLevel[i];
                points[i] = p;
            }
            int zChange = (int)(farPlaneDistance - nearPlaneDistance);
            for (int i = 0; i < pointsZLevel.Length; i++)
            {
                pointsZLevel[i] = pointsZLevel[i] - minZLevel;
                if (pointsZLevel[i] == 0)
                {
                    pointsZLevel[i] = nearPlaneDistance;
                    continue;
                }
                pointsZLevel[i] = nearPlaneDistance + (pointsZLevel[i] / (maxZLevel - minZLevel)) * zChange;
            }
            facesNormal = new Vector3[faces.Count];
            for (int i = 0; i < faces.Count; i++)
            {
                Vector3 v12 = new Vector3(points[faces[i].VerticesInd[1]].X - points[faces[i].VerticesInd[0]].X, points[faces[i].VerticesInd[1]].Y - points[faces[i].VerticesInd[0]].Y, backfacePointsZLevel[faces[i].VerticesInd[1]] - backfacePointsZLevel[faces[i].VerticesInd[0]]);
                Vector3 v13 = new Vector3(points[faces[i].VerticesInd[faces[i].Count - 1]].X - points[faces[i].VerticesInd[0]].X, points[faces[i].VerticesInd[faces[i].Count - 1]].Y - points[faces[i].VerticesInd[0]].Y, backfacePointsZLevel[faces[i].VerticesInd[faces[i].Count - 1]] - backfacePointsZLevel[faces[i].VerticesInd[0]]);
                facesNormal[i] = Vector3.Cross(v12, v13);
            }

        }

        private Vector4 MultiplyVector(Matrix4x4 m, Vector4 v)
        {
            float x = m.M11 * v.X + m.M21 * v.Y + m.M31 * v.Z + m.M41 * v.W;
            float y = m.M12 * v.X + m.M22 * v.Y + m.M32 * v.Z + m.M42 * v.W;
            float z = m.M13 * v.X + m.M23 * v.Y + m.M33 * v.Z + m.M43 * v.W;
            float w = m.M14 * v.X + m.M24 * v.Y + m.M34 * v.Z + m.M44 * v.W;
            return new Vector4(x, y, z, w);
        }

        private void Draw()
        {
            Bitmap b = new Bitmap(raster.Width, raster.Height);
            Graphics g = Graphics.FromImage(b);
            if (drawFacesCheckBox.Checked && drawFogCheckBox.Checked)
                g.Clear(fogColor);
            else
                g.Clear(Color.Black);
            if (drawFacesCheckBox.Checked)
            {
                if (transparentFacesCheckBox.Checked)
                {
                    for (int i = 0; i < faces.Count; i++)
                    {
                        if (!transparentFaces[i])
                        {
                            drawFace(ref b, i);
                        }
                    }
                    for (int i = 0; i < faces.Count; i++)
                    {
                        if (transparentFaces[i])
                        {
                            drawFace(ref b, i, 0.5f);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < faces.Count; i++)
                    {
                        drawFace(ref b, i);
                    }
                }
                if (drawFogCheckBox.Checked)
                {
                    for (int i = 0; i < b.Width; i++)
                    {
                        for (int j = 0; j < b.Height; j++)
                        {
                            if (zLevel[i, j] > farPlaneDistance || zLevel[i, j] < nearPlaneDistance)
                            {
                                continue;
                            }
                            float f = (farPlaneDistance - Math.Abs(zLevel[i, j])) / (farPlaneDistance - nearPlaneDistance);
                            Color oldColor = b.GetPixel(i, j);
                            int nRed = (int)((1 - f) * fogColor.R + f * oldColor.R);
                            int nGreen = (int)((1 - f) * fogColor.G + f * oldColor.G);
                            int nBlue = (int)((1 - f) * fogColor.B + f * oldColor.B);
                            Color nColor = Color.FromArgb(nRed, nGreen, nBlue);
                            b.SetPixel(i, j, nColor);
                        }
                    }
                }
            }
            if (drawPointsCheckBox.Checked && !drawEdgesCheckBox.Checked)
            {
                foreach (PointF p in points) //draw points
                {
                    if (p.X >= 0 && p.X < b.Width && p.Y >= 0 && p.Y < b.Height)
                        b.SetPixel((int)p.X, (int)p.Y, Color.White);
                }
            }
            if (drawEdgesCheckBox.Checked)
            {
                foreach ((int, int) vl in verticesIndLines) //draw all edges
                {
                    new Line(points[vl.Item1], points[vl.Item2], (float)vertices[vl.Item1].Z, (float)vertices[vl.Item2].Z).Draw(ref b);
                }
            }
            raster.Image = b;
            raster.Refresh();
        }

        private void drawFace(ref Bitmap b, int ind, float alpha = 1.0f)
        {
            Face f = faces[ind];
            Point[] facePoints = new Point[f.Count];
            for (int i = 0; i < f.Count; i++)
            {
                facePoints[i] = points[f.VerticesInd[i]];
            }
            float[] facePointsZ = new float[f.Count];
            float[] backfaceFacePointsZ = new float[f.Count];
            for (int i = 0; i < f.Count; i++)
            {
                facePointsZ[i] = pointsZLevel[f.VerticesInd[i]];
                backfaceFacePointsZ[i] = backfacePointsZLevel[f.VerticesInd[i]];
            }
            if (!disabledBackfaceCulling.Checked)
            {
                Vector3 N = facesNormal[ind];
                Vector3 S = new Vector3(cameraPosition.X - facePoints[0].X, cameraPosition.Y - facePoints[0].Y, cameraPosition.Z - backfaceFacePointsZ[0]);

                float dotProduct = N.X * S.X + N.Y * S.Y + N.Z * S.Z;
                if ((backfaceCulling.Checked && dotProduct < 0) || (reverseBackfaceCulling.Checked && dotProduct > 0))
                    return;
            }
            if (textureFaces.Checked)
                f.Draw(ref b, facePoints, ref zLevel, facePointsZ, zBufforCheckBox.Checked, ind, alpha, texture);
            else
                f.Draw(ref b, facePoints, ref zLevel, facePointsZ, zBufforCheckBox.Checked, ind, alpha);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "OFF Files|*.off";
            openFileDialog1.Title = "Select OFF File";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadFile(openFileDialog1.FileName, openFileDialog1.SafeFileName);
            }
        }

        private void loadFile(string filePath, string fileName)
        {
            faces = new List<Face>();
            vertices = new List<Vector3>();
            verticesIndLines = new List<(int, int)>();

            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            int[] nValues = (sr.ReadLine()).Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < nValues[0]; i++) //reading vertices
            {
                float[] tVertice = (sr.ReadLine()).Replace('.', ',').Split(' ').Select(x => float.Parse(x)).ToArray();
                vertices.Add(new Vector3(tVertice[0], tVertice[1], tVertice[2]));
            }
            Random rnd = new Random();
            for (int i = 0; i < nValues[1]; i++) //reading faces
            {
                int[] tFace = (sr.ReadLine()).Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray();
                int[] tFaceVertices = new int[tFace[0]];
                for (int k = 0; k < tFace[0]; k++)
                    tFaceVertices[k] = tFace[k + 1];
                for (int k = 0; k < tFace[0] - 1; k++) //storing lines based on vertices indexes
                {
                    if (!verticesIndLines.Contains((tFaceVertices[k], tFaceVertices[k + 1])) && !verticesIndLines.Contains((tFaceVertices[k + 1], tFaceVertices[k])))
                        verticesIndLines.Add((tFaceVertices[k], tFaceVertices[k + 1]));
                }
                if (!verticesIndLines.Contains((tFaceVertices[0], tFaceVertices[tFace[0] - 1])) && !verticesIndLines.Contains((tFaceVertices[tFace[0] - 1], tFaceVertices[0])))
                    verticesIndLines.Add((tFaceVertices[0], tFaceVertices[tFace[0] - 1]));
                faces.Add(new Face(tFace[0], tFaceVertices, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))));
            }
            sr.Close();
            loadLabel.Text = $"Loaded {fileName}\n{vertices.Count} vertices\n{faces.Count} faces\n{verticesIndLines.Count} lines";

            transparentFacesNumber.Value = 0;
            transparentFacesNumber.Maximum = faces.Count;
            transparentFaces = new bool[faces.Count];

            cameraPosition = new Vector3(10, 0, 0);
            cameraTarget = new Vector3(0, 0, 0);
            objectRotation = new Vector3(0, 0, 0);
            upVector = new Vector3(0, 1, 0);

            drawFacesCheckBox.Checked = false;
            drawEdgesCheckBox.Checked = false;
            drawPointsCheckBox.Checked = true;
            zBufforCheckBox.Checked = false;
            disabledBackfaceCulling.Checked = true;
            solidFaces.Checked = true;
            drawFogCheckBox.Checked = false;
            transparentFacesCheckBox.Checked = false;
            refreshScreen();
        }

        private void refreshScreen()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            CalculatePoints();
            Draw();
            stopWatch.Stop();
            fps = (int)(1.0 / (stopWatch.ElapsedMilliseconds / 1000.0));
            updateText();
        }

        private void updateText()
        {
            FPSLabel.Text = $"FPS: {fps}";
            rotationLabel.Text = $"Rotation x: {objectRotation.X % 360}°\nRotation y: {objectRotation.Y % 360}°\nRotation z: {objectRotation.Z % 360}°";
        }

        private void raster_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
                cameraPosition.X -= (float)e.Delta / 1000;
            else
                cameraPosition.X -= (float)e.Delta / 100;
            refreshScreen();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W when e.Modifiers == Keys.None:
                    cameraTarget.Y += 0.05f;
                    break;
                case Keys.S when e.Modifiers == Keys.None:
                    cameraTarget.Y -= 0.05f;
                    break;
                case Keys.A when e.Modifiers == Keys.None:
                    cameraTarget.Z += 0.05f;
                    break;
                case Keys.D when e.Modifiers == Keys.None:
                    cameraTarget.Z -= 0.05f;
                    break;
                case Keys.E when e.Modifiers == Keys.None:
                    cameraPosition.X += 0.1f;
                    break;
                case Keys.Q when e.Modifiers == Keys.None:
                    cameraPosition.X -= 0.1f;
                    break;
                case Keys.D when e.Modifiers == Keys.Shift:
                    objectRotation.Z += 1f;
                    break;
                case Keys.A when e.Modifiers == Keys.Shift:
                    objectRotation.Z -= 1f;
                    break;
                case Keys.S when e.Modifiers == Keys.Shift:
                    objectRotation.Y += 1f;
                    break;
                case Keys.W when e.Modifiers == Keys.Shift:
                    objectRotation.Y -= 1f;
                    break;
                case Keys.E when e.Modifiers == Keys.Shift:
                    objectRotation.X += 1f;
                    break;
                case Keys.Q when e.Modifiers == Keys.Shift:
                    objectRotation.X -= 1f;
                    break;
            }
            refreshScreen();
        }

        private void refreshScreenEvent(object sender, EventArgs e)
        {
            refreshScreen();
        }

        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Load texture";
            openFileDialog1.Filter = "JPG Files|*.jpg|PNG files|*.png*|BMP files|*.bmp*|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                texture = new Bitmap(openFileDialog1.OpenFile());
                textureView.Image = texture;
                textureView.Refresh();
                refreshScreen();
            }
        }

        private void fogColorView_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fogColor = colorDialog1.Color;
                Graphics g = Graphics.FromImage(fogColorView.Image);
                g.Clear(fogColor);
                fogColorView.Refresh();
                refreshScreen();
            }
        }

        private void transparentFacesNumber_ValueChanged(object sender, EventArgs e)
        {
            Random rand = new Random();
            List<int> randomList = new List<int>();
            transparentFaces = new bool[faces.Count];
            while (randomList.Count < transparentFacesNumber.Value)
            {
                int r = rand.Next(0, faces.Count);
                if (!randomList.Contains(r))
                    randomList.Add(r);
            }
            for (int i = 0; i < randomList.Count; i++)
            {
                transparentFaces[randomList[i]] = true;
            }
            refreshScreen();
        }
    }
}