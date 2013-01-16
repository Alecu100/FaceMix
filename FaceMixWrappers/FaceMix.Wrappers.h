// FaceMix.Wrappers.h

#pragma once



#include "niflib.h"
#include "obj\niobject.h"
#include "obj\nitrishapedata.h"
#include "obj\nitrishape.h"
#include "obj\nitristrips.h"
#include "obj\nitristripsdata.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;
using namespace FaceMix::Core;

using Niflib::NiObject;
using Niflib::NiTriShapeData;
using Niflib::NiTriShapeDataRef;
using Niflib::NiTriShape;
using Niflib::NiTriShapeRef;
using Niflib::NiObjectRef;
using Niflib::Vector3;
using Niflib::Triangle;
using Niflib::Ref;
using std::vector;
using Niflib::NiGeometryData;
using Niflib::NiTriStrips;
using Niflib::NiTriStripsData;
using Niflib::NiTriStripsRef;
using Niflib::NiTriStripsDataRef;

namespace FaceMix {

	namespace Wrappers {
		
		class NifContainer {
		public:
			std::vector< Niflib::Ref<Niflib::NiObject> > scene;
			NifContainer(char* tmp,int size);
			virtual ~NifContainer();
		};
		
		public ref class NifFile
		{
			// TODO: Add your methods for this class here.
		public:

			property List<MeshBase^>^ MeshData
			{
				List<MeshBase^>^ get()
				{
					return this->meshData;
				}
				void set(List<MeshBase^>^ x)
				{
					this->meshData = gcnew List<MeshBase^>(x);
				}
			}
			
			property List<unsigned char>^ BinaryData
			{
				List<unsigned char>^ get()
				{
					return this->binaryData;
				}
				void set(List<unsigned char>^ x)
				{
					this->binaryData = gcnew List<unsigned char>(x);
				}
			}
			
			NifFile();

			NifFile(String^ name);

			NifFile(FileStream^ stream);

			NifFile(NifFile^ niffile);

			void WriteToFile(FileStream^ stream);

			virtual ~NifFile();

		private:

			List<unsigned char>^ binaryData;

			List<MeshBase^>^ meshData;

			NifContainer* sceneWrapper;

		};

		namespace Obsolete {
			public value class VertexPosition
		{
		public:
			VertexPosition(BinaryReader^ reader);
			void Write(BinaryWriter^ writer);

			property float X
			{
				float get()
				{
					return this->x;
				}
				void set(float _x)
				{
					this->x = _x;
				}
			}

			property float Y
			{
				float get()
				{
					return this->y;
				}
				void set(float _y)
				{
					this->y = _y;
				}
			}

			property float Z
			{
				float get()
				{
					return this->z;
				}
				void set(float _z)
				{
					this->z = _z;
				}
			}

		private:
			float x;
			float y;
			float z;
		};

		public value class VertexDisplacement
		{
		public:
			VertexDisplacement(BinaryReader^ reader);
			void Write(BinaryWriter^ writer);

			property short X
			{
				short get()
				{
					return this->x;
				}
				void set(short _x)
				{
					this->x = _x;
				}
			}

			property short Y
			{
				short get()
				{
					return this->y;
				}
				void set(short _y)
				{
					this->y = _y;
				}
			}

			property short Z
			{
				short get()
				{
					return this->z;
				}
				void set(short _z)
				{
					this->z = _z;
				}
			}

		private:
			short x;
			short y;
			short z;
		};
		}
	}
}
