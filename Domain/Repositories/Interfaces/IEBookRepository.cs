﻿namespace Domain
{
    public interface IEBookRepository
    {
        public EBook Create(CreateEBookDto createEBookDto);
        public EBook Update(string id, UpdateEBookDto updateEBookDto);
        public void Delete(string id);
        public EBook GetById(string id);
        public List<EBook> GetAll();
    }
}
