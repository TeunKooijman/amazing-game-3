﻿using AmazingGame3.Dialogs;
using AmazingGame3.Extensions;
using AmazingGame3.Infrastructure;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Bar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class LunaBoulder : PersonBase
    {
        public static int ID = 22;

        public LunaBoulder()
            : base(ID, name: "Maantje", description: "Je vastgebonden wijf.")
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
        {
            return new DialogBuilder("Jasper wat fijn dat je me hebt gered. Bedankt en tot ziens.")
                .AddResponse("Wat? Gaan we niet eens neuken?", "Ohh ja", 
                    onChosenAsync: async state => 
                    {
                        await console.WriteLineAsync("Je trekt je broekie in één vloeiende beweging uit en gaat er in.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT)); 
                    }, 
                    buildAction: continuation =>
                    {
                        continuation.AddResponse("Stoot 1", "Ooh", continuation => 
                        {
                            continuation.AddResponse("Stoot 2", "Aah", 
                                onChosenAsync: async state => 
                                {
                                    await console.WriteLineAsync("Je bent klaar.".Pastel(GameEngine.COLOR_INTERMEDIATE_TEXT)); 
                                }, 
                                buildAction: continuation => 
                                {
                                    continuation.AddResponse("Laten we naar de Jans Bar gaan om te vieren. Eén biertje.", onChosenAsync: state => 
                                    {
                                        state.CurrentRoom = roomProvider.GetRoom(Jansbar.ID);
                                        return Task.CompletedTask;
                                    });
                                });
                        });
                    })
                .Build();
        }
    }
}
