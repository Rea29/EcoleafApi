using Common.Constants;
using Common.ViewModels;
using GreenDonut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Constants.StoredProcedures;
using static HotChocolate.ErrorCodes;

namespace Common.Helpers.FileUpload
{
	public class FileUploadHelper : IFileUploadHelper
	{
		
		public async Task<CustomModelResponse> SaveFile(IFile file, string targetFolderPath, string fileName)
		{
			var response = new CustomModelResponse("The server is temporarily unavailable please try again later.", 500, false);

			try
			{
				if (!Directory.Exists(targetFolderPath))
					Directory.CreateDirectory(targetFolderPath);

				using (var fileStream = new FileStream($"{targetFolderPath}{fileName}", FileMode.Create))
					await file.CopyToAsync(fileStream);

				response = new CustomModelResponse(ApiResponseMessage.SUCCESS, 200, true);
			}
			catch(Exception ex) {
				var errMsg = (ex.InnerException is null) ? ex.Message : ex.InnerException.Message;
				response = new CustomModelResponse(errMsg, 500, false);
			}

			return response;
		}

		public double GetFileSizeMB(IFile file)
		{
			long bytes = file.Length.Value;
			return (bytes / 1024f) / 1024f;
		}

		public bool CheckIfImageFileType(string fileName)
		{
			string[] validFileExtensions = { ".jpg", ".jpeg", ".png", ".svg", ".JPG", ".JPEG", ".PNG", ".SVG" };
			string ext = System.IO.Path.GetExtension(fileName);

			return validFileExtensions.Contains(ext);

		}

		public bool CheckImageDimension(IFile file)
		{
			bool isOkay = false;
			Image image = Image.FromStream(file.OpenReadStream());

			var width = image.Width;
			var height = image.Height;

			if ( width >= 100 && width <=500 )
			{
				if (height >= 100 && height <= 500)
				{
					isOkay = true;
				}
			}
			return isOkay;
		}
        public bool CheckImageDimensionMax500x500(IFile file)
        {
            bool isOkay = false;
            Image image = Image.FromStream(file.OpenReadStream());

            var width = image.Width;
            var height = image.Height;

            if (width <= 500 && width <= 500)
            {
                    isOkay = true;
                
            }
            return isOkay;
        }


        public async Task<bool> DeleteFile(string targetFolderPath, string fileName)
		{
			bool isOkay = false;

			string filePath = $"{targetFolderPath}{fileName}";

			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
					isOkay = true;
				}
			} catch(Exception ex)
			{
				var errMsg = ex.Message;
			}

			return isOkay;
		}
	}
}
