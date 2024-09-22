﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Threading;

namespace MintPlayer.SourceGenerators.Tools
{

    public abstract class Producer
    {
        protected Producer(string rootNamespace)
        {
            RootNamespace = rootNamespace;
        }

        public const string Header = """
        //------------------------------------------------------------------------------
        // <auto-generated>
        //    This code was generated from source generator.
        //
        //    Manual changes to this file may cause unexpected behavior in your application.
        //    Manual changes to this file will be overwritten if the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------
        """;

        public string RootNamespace { get; }

        protected abstract ProducedSource ProduceSource(CancellationToken cancellationToken);

        public void Produce(SourceProductionContext context)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            var result = ProduceSource(context.CancellationToken);
            if (result is { FileName: not null, Source: not null } producedSource)
            {
                context.AddSource(producedSource.FileName, SourceText.From(producedSource.Source, Encoding.UTF8));
            }
        }
    }
}