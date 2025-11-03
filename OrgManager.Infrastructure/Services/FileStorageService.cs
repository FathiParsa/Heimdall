using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using OrgManager.Application.Contracts.Infrastructure;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;

    public FileStorageService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration["BlobStorage:ConnectionString"]);
        _containerName = configuration["BlobStorage:ContainerName"];
    }

    public async Task<string> UploadAsync(Stream fileStream, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileStream, true);
        return blobClient.Uri.ToString();
    }
}
