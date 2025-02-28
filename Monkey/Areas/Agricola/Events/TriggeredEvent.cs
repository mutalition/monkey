﻿using Monkey.Games.Agricola.Cards;
using Monkey.Games.Agricola.Events.Triggers;
using Monkey.Games.Agricola.Notification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Monkey.Games.Agricola.Events
{
    public abstract class TriggeredEvent : GameEvent
    {
        public TriggeredEvent(XElement definition)
            :base(definition)
        {
            UntilExecution = Int32.MaxValue;
            
            Triggers = definition.Descendants("Trigger").Select(GameEventTrigger.Create).ToArray();
            if (definition.Attribute("UntilExecution") != null)
                UntilExecution = (int)definition.Attribute("UntilExecution");
            if (definition.Attribute("FromExecution") != null)
                FromExecution = (int)definition.Attribute("FromExecution");
        }

        public TriggeredEvent(GameEventTrigger[] triggers)
            :base()
        {
            UntilExecution = Int32.MaxValue;
            Triggers = triggers;
        }

        new public static TriggeredEvent Create(XElement options)
        {
            var cls = (string)options.Attribute("Class");
            var type = Type.GetType(cls);

            return (TriggeredEvent)Activator.CreateInstance(type, options);
        }

        public static TriggeredEvent Create(XElement options, Card owningCard)
        {
            return TriggeredEvent.Create(options);
        }

        [JsonIgnore]
        public readonly GameEventTrigger[] Triggers;

        [JsonIgnore]
        public readonly int FromExecution;

        [JsonIgnore]
        public readonly int UntilExecution;

    }
}