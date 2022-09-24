﻿namespace RentBizu.Data
{
    public interface IAzureBlobStorage
    {
        Task<string> UploadFile(string fileName, Stream buffer, string directory = "");
    }
}