using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codenames.Models;

namespace Codenames.BLL.Interfaces
{
    public interface IGameService
    {
        Task<Room> CreateRoom(Guid ownerId);
        Task AddPlayerToRoom(Guid roomId, Guid playerId);
        Task RemovePlayerFromRoom(Guid roomId, Guid playerId);
        Task GenerateField(Guid roomId);

    }
}
