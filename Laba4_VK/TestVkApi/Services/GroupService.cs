using System.Collections.Generic;
using Tests.Models;
using Tests.Repositories;

namespace Tests.Services
{
    public class GroupService
    {
        private IGroupRepository _groupsRepository;

        public GroupService(IGroupRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public Group GetById(string id)
        {
            return _groupsRepository.GetById(id);
        }

        public List<Group> Get(string id, string count)
        {
            return _groupsRepository.Get(id,count);
        }
    }

}