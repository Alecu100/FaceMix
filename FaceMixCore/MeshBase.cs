using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceMix.Core
{
    public class MeshBase
    {
        protected string name;
        protected List<VertexPosition> vertices;
        protected List<TriangleFace> triangleFaces;
        protected List<QuadFace> quadFaces;

        public virtual string Name { get { return this.name; } set { this.name = value; } }
        public virtual List<VertexPosition> Vertices { get { return this.vertices; } set { this.vertices = new List<VertexPosition>(value); } }
        public virtual List<TriangleFace> TriangleFaces { get { return this.triangleFaces; } set { this.triangleFaces = new List<TriangleFace>(value); } }
        public virtual List<QuadFace> QuadFaces { get { return this.quadFaces; } set { this.quadFaces = new List<QuadFace>(value); } }

        public MeshBase()
        {
            this.name = "";
            this.vertices = new List<VertexPosition>();
            this.triangleFaces = new List<TriangleFace>();
            this.quadFaces = new List<QuadFace>();
        }

        public MeshBase(MeshBase mesh)
        {
            this.name = mesh.name.Clone() as string;
            this.vertices = new List<VertexPosition>(mesh.vertices);
            this.triangleFaces = new List<TriangleFace>(mesh.triangleFaces);
            this.quadFaces = new List<QuadFace>(mesh.quadFaces);
        }
    }
}
