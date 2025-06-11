﻿using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetBrandByIdQuery(string Id) : IRequest<BrandResponse>
    {
    }
}