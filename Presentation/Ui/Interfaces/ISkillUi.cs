using Domain;

namespace Presentation
{
    public interface ISkillUi
    {
        CreateSkillDto Create();
        UpdateSkillDto Update();
        string Delete();
    }
}
