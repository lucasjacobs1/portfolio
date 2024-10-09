using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;

namespace BusinessLayer.Logic
{
    public class CommunityLogic : ICommunityLogic
    {
        private readonly ICommunityRepository _communityRespository;
        private readonly IMessagingLogic _messagingLogic;
        public CommunityLogic(ICommunityRepository userRepository, IMessagingLogic messagingLogic)
        {
            _communityRespository = userRepository;
            _messagingLogic = messagingLogic;
        }

        public bool CreateCommunity(CreateCommunityRequest request)
        {
            CommunityModel communityModel = new CommunityModel()
            {
                CommunityCreated = DateTime.Now,
                Description = request.CommunityDescription,
                MemberCount = 0,
                Name = request.CommunityName,
                OrganizerId = request.OrganizerId,
            };

            var created = _communityRespository.Create(communityModel);
            if (!created) { throw new ArgumentException("Could not be created."); }
            return true;
        }

        public bool UpdateCommunity(UpdateCommunityRequest request)
        {
            CommunityModel existing = _communityRespository.GetById(request.CommunityId);
            if (existing == null)
            {
                throw new ArgumentException("Community can not be found");
            }
            var oldName = existing.Name;
            existing.Description = request.CommunityDescription;
            existing.Name = request.CommunityName;
            var result = _communityRespository.Update(existing);
            if (!result) { throw new ArgumentException("Community is not updated."); }

            if (oldName != request.CommunityName)
            {
                _messagingLogic.Publish("community_update", "community_update", $"The name of the community {oldName} has changed to {request.CommunityName}.");
            }
            return true;
        }

        public CommunityResponse GetCommunityByIdAsync(int communityId)
        {
            CommunityModel community = _communityRespository.GetById(communityId);
            if (community != null)
            {
                CommunityResponse communityResponse = new CommunityResponse()
                {
                    Id = communityId,
                    Name = community.Name,
                };
                return communityResponse;
            }
            else { throw new ArgumentException(); }

        }

        public bool DeleteCommunity(int communityId)
        {
            CommunityModel community = _communityRespository.GetById(communityId);
            if (community == null) { throw new ArgumentException(); }

            var isCommunityDeleted = _communityRespository.Delete(community);
            if (!isCommunityDeleted)
            {
                throw new ArgumentException();
            }
            return true;
        }
    }
}
