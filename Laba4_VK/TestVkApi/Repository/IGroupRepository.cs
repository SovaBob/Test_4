using System.Collections.Generic;
using Tests.Models;

namespace Tests.Repositories
{
    public interface IGroupRepository
    {
        Group GetById(string Id);
        List<Group> Get(string Id, string count);
    }
}
