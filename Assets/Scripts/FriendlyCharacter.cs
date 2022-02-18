public class FriendlyCharacter : BaseCharacter
{
    private DialogueSystem _dialogueSystem;

    public FriendlyCharacter()
    {
        _myStats.DMG = 0;
        _myStats.LIFE= 20;
        _myStats.LIFE_CAP = 20;
        _myStats.SPEED = 0;
        _myStats.RANGE = 0;
        _myStats.EXPERIENCE = 10;
        _myStats.EXPERIENCE_CAP = 0;

        _dialogueSystem = new DialogueSystem();
    }

    public FriendlyCharacter(float p_life, float p_lifeCap)
    {
        _myStats.DMG = 0;
        _myStats.LIFE = p_life;
        _myStats.LIFE_CAP = p_lifeCap;
        _myStats.SPEED = 0;
        _myStats.RANGE = 0;
        _myStats.EXPERIENCE = 10;
        _myStats.EXPERIENCE_CAP = 0;
        
        _dialogueSystem = new DialogueSystem();
    }

    public void SetDialogueSystem(DialogueSystem dialogue)
    {
        _dialogueSystem = dialogue;
    }
    public DialogueSystem GetDialogueSystem()
    {
        return _dialogueSystem;
    }
}