using MediatR;
using OrgManager.Application.Contracts.Infrastructure;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Chat.Commands.SendMessage;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
{
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IFileStorageService _fileStorageService;

    public SendMessageCommandHandler(IChatMessageRepository chatMessageRepository, IFileStorageService fileStorageService)
    {
        _chatMessageRepository = chatMessageRepository;
        _fileStorageService = fileStorageService;
    }

    public async Task Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        if (request.Attachment != null)
        {
            var attachmentUrl = await _fileStorageService.UploadAsync(request.Attachment.OpenReadStream(), request.Attachment.FileName);
            var fileType = request.Attachment.ContentType.StartsWith("image") ? FileType.Image : FileType.File;
            var chatMessage = ChatMessage.CreateAttachment(request.ChatRoomId, request.UserId, request.Message, attachmentUrl, fileType);
            await _chatMessageRepository.AddAsync(chatMessage);
        }
        else
        {
            var chatMessage = ChatMessage.CreateText(request.ChatRoomId, request.UserId, request.Message);
            await _chatMessageRepository.AddAsync(chatMessage);
        }
    }
}
