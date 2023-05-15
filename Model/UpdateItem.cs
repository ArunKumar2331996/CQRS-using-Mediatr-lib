﻿using MediatR;

namespace Mediator_Pattern.Model
{
    public class UpdateItem:IRequest<Response>
    {
        private readonly Item _item;
        public UpdateItem(Item item)
        {
            _item = item;
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            Completed = item.Completed;
        }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Completed { get; set; }
    }
}
