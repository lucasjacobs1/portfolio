using BusinessLayer.DTO.Requests;
using BusinessLayer.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// A service to perform business operations for community management
    /// </summary>
    public interface ICommunityLogic
    {
        /// <summary>
        /// Get a community by id
        /// </summary>
        /// <param name="communityId"></param>
        /// <returns>
        /// CommunityResponse
        /// </returns>
        CommunityResponse GetCommunityByIdAsync(int communityId);

        /// <summary>
        /// Create a community
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// bool
        /// </returns>
        bool CreateCommunity(CreateCommunityRequest request);
        /// <summary>
        /// Update a community
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// bool
        /// </returns>
        bool UpdateCommunity(UpdateCommunityRequest request);
    }
}
