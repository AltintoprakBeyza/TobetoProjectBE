﻿using System;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.TownRequests;
using Business.Dtos.Responses.TownResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

    public class TownManager : ITownService
    {
        ITownDal _townDal;
        IMapper _mapper;

        public TownManager(ITownDal townDal, IMapper mapper)
        {
            _townDal = townDal;
            _mapper = mapper;
        }

        public async Task<CreatedTownResponse> AddAsync(CreateTownRequest createTownRequest)
        {
            Town town = _mapper.Map<Town>(createTownRequest);
            Town createdTown = await _townDal.AddAsync(town);
            CreatedTownResponse createdTownResponse = _mapper.Map<CreatedTownResponse>(createdTown);
            return createdTownResponse;
        }

        public async Task<Town> DeleteAsync(int id)
        {
            var data = await _townDal.GetAsync(i => i.Id == id);
            var result = await _townDal.DeleteAsync(data);
            return result;
        }

        public async Task<IPaginate<GetListTownResponse>> GetAllAsync(PageRequest pageRequest)
        {
            var data = await _townDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
               );
            var result = _mapper.Map<Paginate<GetListTownResponse>>(data);
            return result;
        }

        public async Task<UpdatedTownResponse> UpdateAsync(UpdateTownRequest updateTownRequest)
        {
            var data = await _townDal.GetAsync(i => i.Id == updateTownRequest.Id);
            _mapper.Map(updateTownRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _townDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedTownResponse>(data);
            return result;
        }
    }


