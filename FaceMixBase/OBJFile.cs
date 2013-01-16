using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using FaceMix.Base;
using FaceMix.Core;

namespace FaceMix
{
    public class OBJFile
    {
        private List<VertexPosition> vertices;
        private List<TriangleFace> triangleFaces;
        private List<QuadFace> quadFaces;
        private MeshBase mesh;

        public List<VertexPosition> Vertices { get { return this.vertices; } }
        public List<TriangleFace> TriangleFaces { get { return this.triangleFaces; } }
        public List<QuadFace> QuadFaces { get { return this.quadFaces; } }
        public MeshBase Mesh { get { return this.mesh; } }

        public OBJFile()
        {
            this.vertices = new List<VertexPosition>();
            this.triangleFaces = new List<TriangleFace>();
            this.quadFaces = new List<QuadFace>();
            this.mesh = new MeshBase();
        }

        public OBJFile(FileStream stream)
        {
            this.vertices = new List<VertexPosition>();
            this.triangleFaces = new List<TriangleFace>();
            this.quadFaces = new List<QuadFace>();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            text = text.Replace("\r", "");
            text = text.Replace('.', ',');
            string[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] words = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                //if (words[0] == "v")
                //{
                //    float x = float.Parse(words[1]);
                //    float y = float.Parse(words[2]);
                //    float z = float.Parse(words[3]);
                //    VertexPosition coord = new VertexPosition(x, y, z);
                //    this.vertices.Add(coord);
                //}
                switch (words[0])
                {
                    case "v":
                        float x = float.Parse(words[1]);
                        float y = float.Parse(words[2]);
                        float z = float.Parse(words[3]);
                        VertexPosition coord = new VertexPosition(x, y, z);
                        this.vertices.Add(coord);
                        break;
                    case "f":
                        if (words.Length == 5)
                        {
                            int a4 = int.Parse(words[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                            int b4 = int.Parse(words[2].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                            int c4 = int.Parse(words[3].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                            int d4 = int.Parse(words[4].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                            QuadFace face4 = new QuadFace(a4, b4, c4, d4);
                            this.quadFaces.Add(face4);
                            break;
                        }      
                        int a = int.Parse(words[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        int b = int.Parse(words[2].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        int c = int.Parse(words[3].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        TriangleFace face = new TriangleFace(a, b, c);
                        this.triangleFaces.Add(face);
                        break;
                }
            }
            this.mesh = new MeshBase();
            this.mesh.QuadFaces = this.quadFaces;
            this.mesh.TriangleFaces = this.triangleFaces;
            this.mesh.Vertices = this.vertices;
            string[] path =  stream.Name.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            this.mesh.Name = HeadFile.ReplaceExtention(path[path.Length - 1],"");
        }
    }
}
