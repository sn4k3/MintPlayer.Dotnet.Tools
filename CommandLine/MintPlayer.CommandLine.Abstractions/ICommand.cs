﻿namespace MintPlayer.CommandLine.Abstractions;

public interface ICommand
{
    public string Name { get; }

    public string Description { get; }
}

public interface ICommand<TInput> : ICommand
{
}