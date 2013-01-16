// This is the main DLL file.

#include "stdafx.h"

#include "FaceMix.Wrappers.h"

using namespace FaceMix::Core;
using namespace System;
using namespace System::Collections::Generic;

namespace FaceMix {
	namespace Wrappers {

		namespace Obsolete {

			VertexDisplacement::VertexDisplacement(BinaryReader^ reader) {
				this->x = reader->ReadInt16();
				this->y = reader->ReadInt16();
				this->z = reader->ReadInt16();
			}

			void VertexDisplacement::Write(BinaryWriter^ writer) {
				writer->Write(this->x);
				writer->Write(this->y);
				writer->Write(this->z);
			}
		
			VertexPosition::VertexPosition(BinaryReader^ reader) {
				this->x = reader->ReadSingle();
				this->y = reader->ReadSingle();
				this->z = reader->ReadSingle();
			}

			void VertexPosition::Write(BinaryWriter^ writer) {
				writer->Write(this->x);
				writer->Write(this->y);
				writer->Write(this->z);
			}
		}
		
		NifContainer::NifContainer(char* tmp,int size) {
			std::stringstream buf(stringstream::binary | stringstream::in | stringstream::out);
			buf.write(tmp,size);
			this->scene = Niflib::ReadNifList(buf);
		}

		NifContainer::~NifContainer() {
		}

		NifFile::NifFile() {
			this->binaryData = gcnew List<unsigned char>();
		}

		NifFile::NifFile(String^ name) {
			char* tmp = new char[name->Length];
			for(int i = 0;i < name->Length; i++)
			{
				tmp[i] = BitConverter::GetBytes(name[i])[0];
			}
			std::string path(tmp,name->Length);
			Niflib::Ref<Niflib::NiObject> file = Niflib::ReadNifTree(path);
		}

		NifFile::NifFile(FileStream^ stream){
			BinaryReader^ reader = gcnew BinaryReader(stream);
			this->binaryData = gcnew List<unsigned char>(reader->ReadBytes(stream->Length - stream->Position));
			this->meshData = gcnew List<MeshBase^>();
			char* tmp = new char[this->binaryData->Count];
			for(int i = 0;i < this->binaryData->Count; i++)
			{
				tmp[i] = this->binaryData[i];
			}
			this->sceneWrapper = new NifContainer(tmp,this->binaryData->Count);
			for(int j = 0;j < this->sceneWrapper->scene.size(); j++)
			{
				NiTriShapeRef test = Niflib::DynamicCast<NiTriShape>(this->sceneWrapper->scene[j]);
				if(test != NULL)
				{
						vector<Vector3> vertices = test->GetData()->GetVertices();
						NiTriShapeDataRef data = Niflib::DynamicCast<NiTriShapeData>(test->GetData());
						if(data != NULL)
						{
							vector<Triangle> triangles = data->GetTriangles();
							MeshBase^ aux = gcnew MeshBase();
							for(int x = 0;x < vertices.size(); x++)
							{
								aux->Vertices->Add(VertexPosition(vertices[x].x,vertices[x].y,vertices[x].z));
							}
							for(int x = 0;x < triangles.size(); x++)
							{
								TriangleFace face(triangles[x].v1,triangles[x].v2,triangles[x].v3);
								aux->TriangleFaces->Add(face);
							}
							array<unsigned char>^ buf= gcnew array<unsigned char>(2);
							buf[1] = 0;
							StringBuilder^ bld = gcnew StringBuilder();
							for(int i = 0;i < test->GetName().size(); i++)
							{
								buf[0] = test->GetName()[i];
								bld->Append(BitConverter::ToChar(buf,0));
							}
							aux->Name = bld->ToString();
							this->meshData->Add(aux);
						}
				}
				NiTriStripsRef test2 = Niflib::DynamicCast<NiTriStrips>(this->sceneWrapper->scene[j]);
				if(test != NULL)
				{
						vector<Vector3> vertices = test->GetData()->GetVertices();
						NiTriStripsDataRef data = Niflib::DynamicCast<NiTriStripsData>(test->GetData());
						if(data != NULL)
						{
							vector<Triangle> triangles = data->GetTriangles();
							MeshBase^ aux = gcnew MeshBase();
							for(int x = 0;x < vertices.size(); x++)
							{
								aux->Vertices->Add(VertexPosition(vertices[x].x,vertices[x].y,vertices[x].z));
							}
							for(int x = 0;x < triangles.size(); x++)
							{
								TriangleFace face(triangles[x].v1,triangles[x].v2,triangles[x].v3);
								aux->TriangleFaces->Add(face);
							}
							array<unsigned char>^ buf= gcnew array<unsigned char>(2);
							buf[1] = 0;
							StringBuilder^ bld = gcnew StringBuilder();
							for(int i = 0;i < test2->GetName().size(); i++)
							{
								buf[0] = test2->GetName()[i];
								bld->Append(BitConverter::ToChar(buf,0));
							}
							aux->Name = bld->ToString();
							this->meshData->Add(aux);
							
						}
				}
			}
			delete tmp;
		}

		NifFile::NifFile(NifFile^ niffile) {
			this->binaryData = gcnew List<unsigned char>(niffile->BinaryData);
			this->meshData = gcnew List<MeshBase^>();
			char* tmp = new char[this->binaryData->Count];
			for(int i = 0;i < this->binaryData->Count; i++)
			{
				tmp[i] = this->binaryData[i];
			}
			this->sceneWrapper = new NifContainer(tmp,this->binaryData->Count);
			for(int j = 0;j < this->sceneWrapper->scene.size(); j++)
			{
				NiTriShapeRef test = Niflib::DynamicCast<NiTriShape>(this->sceneWrapper->scene[j]);
				if(test != NULL)
				{
						vector<Vector3> vertices = test->GetData()->GetVertices();
						NiTriShapeDataRef data = Niflib::DynamicCast<NiTriShapeData>(test->GetData());
						if(data != NULL)
						{
							vector<Triangle> triangles = data->GetTriangles();
							MeshBase^ aux = gcnew MeshBase();
							for(int x = 0;x < vertices.size(); x++)
							{
								aux->Vertices->Add(VertexPosition(vertices[x].x,vertices[x].y,vertices[x].z));
							}
							for(int x = 0;x < triangles.size(); x++)
							{
								TriangleFace face(triangles[x].v1,triangles[x].v2,triangles[x].v3);
								aux->TriangleFaces->Add(face);
							}
							this->meshData->Add(aux);
						}
				}
				NiTriStripsRef test2 = Niflib::DynamicCast<NiTriStrips>(this->sceneWrapper->scene[j]);
				if(test != NULL)
				{
						vector<Vector3> vertices = test->GetData()->GetVertices();
						NiTriStripsDataRef data = Niflib::DynamicCast<NiTriStripsData>(test->GetData());
						if(data != NULL)
						{
							vector<Triangle> triangles = data->GetTriangles();
							MeshBase^ aux = gcnew MeshBase();
							for(int x = 0;x < vertices.size(); x++)
							{
								aux->Vertices->Add(VertexPosition(vertices[x].x,vertices[x].y,vertices[x].z));
							}
							for(int x = 0;x < triangles.size(); x++)
							{
								TriangleFace face(triangles[x].v1,triangles[x].v2,triangles[x].v3);
								aux->TriangleFaces->Add(face);
							}
							this->meshData->Add(aux);
						}
				}
			}
			delete tmp;
		}

		void NifFile::WriteToFile(FileStream^ stream) {
			BinaryWriter^ writer = gcnew BinaryWriter(stream);
			writer->Write(this->binaryData->ToArray());
		}


		NifFile::~NifFile() {
			delete this->sceneWrapper;
		}
	}
}
