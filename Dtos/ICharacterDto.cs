namespace Dtos
{
    public interface ICharacterDto
    {
        Character? GetRecordById(Guid id);
        Dictionary<Guid, Character> SearchCharacters(CharacterSearchRequest csr);
        Guid AddCharacter(Character ch);
        bool Delete(Guid id);
        bool Update(Guid id, Character newChar);
        void AddRecords();
    }
}
