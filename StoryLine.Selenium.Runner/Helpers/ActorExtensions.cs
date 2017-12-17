using System;
using StoryLine.Contracts;
using StoryLine.Utils.Expectations;

namespace StoryLine.Selenium.Runner.Helpers
{
    public static class ActorExtensions
    {
        public static IActor Does<TActionBuilder>(this IActor actor, Action<TActionBuilder> config)
            where TActionBuilder : IActionBuilder, new()
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            Scenario.New()
                .When(actor)
                    .Performs(config)
                .Run();

            return actor;
        }

        public static IActor Does<TActionBuilder, TArtifact1>(this IActor actor, Action<TActionBuilder, TArtifact1> config, Func<TArtifact1, bool> predicate1 = null)
            where TActionBuilder : IActionBuilder, new()
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            Scenario.New()
                .When(actor)
                    .Performs(config, predicate1)
                .Run();

            return actor;
        }

        public static IActor Expects<TExpectationBuilder>(this IActor actor, Action<TExpectationBuilder> config)
            where TExpectationBuilder : IExpectationBuilder, new()
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            Scenario.New()
                .When(actor)
                    .Performs<Nothing>()
                .Then()
                    .Expects(config)
                .Run();

            return actor;
        }

        public static IActor ExpectsArtifact<TArtifact>(this IActor actor, Func<TArtifact, bool> predicate)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            Scenario.New()
                .When(actor)
                    .Performs<Nothing>()
                .Then()
                    .Expects<Artifact<TArtifact>>(x => x.Meets(predicate))
                .Run();

            return actor;
        }

        public static IActor ExpectsArtifact<TArtifact>(this IActor actor, Action<TArtifact> assertion)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (assertion == null)
                throw new ArgumentNullException(nameof(assertion));

            Scenario.New()
                .When(actor)
                    .Performs<Nothing>()
                .Then()
                    .Expects<Artifact<TArtifact>>(x => x.Meets(assertion))
                .Run();

            return actor;
        }

        private class Nothing : IActionBuilder, IAction
        {
            public IAction Build()
            {
                return this;
            }

            public void Execute(IActor actor)
            {
            }
        }
    }
}
