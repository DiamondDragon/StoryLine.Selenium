using System;
using StoryLine.Contracts;
using StoryLine.Selenium.Actions;
using StoryLine.Selenium.Selectors;

namespace StoryLine.Selenium.Runner.Helpers
{
    public static class Aliases
    {
        public static IActor NavigatesTo(this IActor actor, string url)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            return actor.Does<Navigate>(x => x.Url(url));
        }

        public static IActor Clicks(this IActor actor, IElementSelector selector)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return actor.Does<Click>(x => x.Element(selector));
        }

        public static IActor Sets<TModel>(this IActor actor, TModel data)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            return actor.Does<SetModel>(x => x.Data(data));
        }

        public static IActor Gets<TModel>(this IActor actor)
        {
            if (actor == null)
                throw new ArgumentNullException(nameof(actor));

            return actor.Does<GetModel>(x => x.Type<TModel>());
        }
    }
}