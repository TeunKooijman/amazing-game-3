using AmazingGame3.Dialogs;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items.Instances;
using AmazingGame3.Rooms;
using AmazingGame3.Rooms.Instances.Boulderhal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class KalendeMan : PersonBase
    {
        public static int ID = 23814;

        public const string DESCRIPTION = @"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀,-----,
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀#_⠀⠀⠀_#
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀a`⠀`a⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀⠀u⠀⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\⠀⠀=⠀⠀/
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|\___⠀/|
⠀⠀⠀⠀⠀⠀⠀⠀___⠀____⠀/:⠀⠀⠀⠀⠀:\____⠀___
⠀⠀⠀⠀⠀⠀.'⠀⠀⠀`.-===-\⠀⠀⠀/-===-.`⠀⠀⠀'.
⠀⠀⠀⠀⠀/⠀⠀⠀⠀⠀⠀.-""""""""""-.-""""""""""-.⠀⠀⠀⠀⠀⠀\
⠀⠀⠀⠀/'⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀=:=⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀'\
⠀⠀.'⠀⠀'⠀.:⠀⠀⠀⠀o⠀⠀⠀-=:=-⠀⠀⠀o⠀⠀⠀⠀:.⠀'⠀⠀`.
⠀⠀(.'⠀⠀⠀/'.⠀'-.....-'-.....-'⠀.'\⠀⠀⠀'.)
⠀⠀/'⠀._/⠀⠀⠀"".⠀⠀⠀⠀⠀--:--⠀⠀⠀⠀⠀.""⠀⠀⠀\_.⠀'\
⠀|⠀⠀.'|⠀⠀⠀⠀⠀⠀"".⠀⠀---:---⠀⠀.""⠀⠀⠀⠀⠀⠀|'.⠀⠀|
⠀|⠀⠀:⠀|⠀⠀⠀⠀⠀⠀⠀|⠀⠀---:---⠀⠀|⠀⠀⠀⠀⠀⠀⠀|⠀:⠀⠀|
⠀⠀\⠀:⠀|⠀⠀⠀⠀⠀⠀⠀|_____._____|⠀⠀⠀⠀⠀⠀⠀|⠀:⠀/
⠀⠀/⠀⠀⠀(⠀⠀⠀⠀⠀⠀⠀|----|------|⠀⠀⠀⠀⠀⠀⠀)⠀⠀⠀\
⠀/⠀...⠀.|⠀⠀⠀⠀⠀⠀|⠀⠀⠀⠀|⠀⠀⠀⠀⠀⠀|⠀⠀⠀⠀⠀⠀|.⠀...\
|::::/⠀''⠀⠀⠀⠀⠀/⠀⠀⠀⠀⠀|⠀⠀⠀⠀⠀⠀⠀\⠀⠀⠀⠀⠀''\::::|
'""""""""⠀⠀⠀⠀⠀⠀⠀/'.L_⠀⠀⠀⠀⠀⠀`\⠀⠀⠀⠀⠀⠀⠀""""""""'
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀/⠀'-.,__/`⠀`\__..-'\
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀;⠀⠀⠀⠀⠀⠀/⠀⠀⠀⠀⠀\⠀⠀⠀⠀⠀⠀;
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀:⠀⠀⠀⠀⠀/⠀⠀⠀⠀⠀⠀⠀\⠀⠀⠀⠀⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀⠀⠀⠀/⠀⠀⠀⠀⠀⠀⠀⠀⠀\.⠀⠀⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|`..⠀/⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀⠀,/
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀(_)⠀|⠀_)
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀⠀⠀|⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀⠀⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀___⠀|⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\___⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀:===|⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|==|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\⠀⠀/⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀__⠀|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀/\/\⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀/⠀""""""`8.__
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|⠀oo⠀|⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\__.//___)
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀|==|
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\__⠀/";

        public KalendeMan()
            : base(ID, name: "Kalende Man", description: DESCRIPTION)
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
        {
            DialogBuilder builder = new DialogBuilder("We leven in een simulatie! De wereld is niet echt! Alles wat we hier zien zijn slechts eentjes en nulletjes, gehost op een kubernetes cluster! Jij en ik hebben nooit bestaan, en zijn nooit geboren! Ons leven is een zieke grap van een prepuberale groep jongeren die dit universum hebben geschept voor hun eigen vermaak! Hun zieke geest heeft onze realiteit gevormd en ..")
                .AddResponse("Wow, OK, jij bent een wappie. Doei");

            return builder.Build();
        }
    }
}
