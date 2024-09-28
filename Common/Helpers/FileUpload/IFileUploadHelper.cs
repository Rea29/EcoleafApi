using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers.FileUpload
{
	public interface IFileUploadHelper
	{
		public Task<CustomModelResponse> SaveFile(IFile file, string targetFolderPath, string fileName);

		public double GetFileSizeMB(IFile file);

		public bool CheckIfImageFileType(string fileName);

		public bool CheckImageDimension(IFile file);
		public bool CheckImageDimensionMax500x500(IFile file);

        public Task<bool> DeleteFile(string targetFolderPath, string fileName);
	}
}
