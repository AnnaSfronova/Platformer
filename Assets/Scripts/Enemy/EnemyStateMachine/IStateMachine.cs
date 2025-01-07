using System;

public interface IStateMachine
{
    public void ChangeState(Type type);
}