﻿using College.Microservice.Entities;
using College.Microservice.Persistence;
using College.Microservice.Protos;
using Grpc.Core;
using System.Threading.Tasks;

namespace College.Microservice.Services
{
    public class AddressBookSvc : AddressBookService.AddressBookServiceBase
    {

        private readonly PersonDbContext _personDbContext;

        public AddressBookSvc(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public override async Task<AddressAdditionResponse> AddUserAddress(AddressAdditionRequest request, ServerCallContext context)
        {
            var userAddress = new AddressData { Name = request.Name, Address = request.Address };

            _personDbContext.Add(userAddress);
            await _personDbContext.SaveChangesAsync();

            var results = new AddressAdditionResponse { Message = "Address Save Successfully." };

            return results;
        }

    }

}
