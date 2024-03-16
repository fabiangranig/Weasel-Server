# Weasel-Server
## Commands
### help
shows all available commands

### weasel create virtual :string:
used to create a virtual weasel, which values are calculated by the software

### weasel create real :string:
used for creating an real weasel object. The created object automatically connects to the weasel server and on startup tries to get the position. Gets the weasel name by name from the "SSI Schäfer Controller". The program crashes if the weasel does not exist. So be careful when using it.

### weasel show
used to show all currently created weasels. Additionally displays the current position of the weasel.

### weasel move :id: :none:waypoint:none:
used to move an virtual or real weasel to the corresponding position. A virtual weasel will block an real weasels pathfinding.

### kuka move :path:
used to move the kuka with an .kmf file that was created previously. The 


kuka virtual -> 
kuka real ->
map show ->
map reserve ->
EE ->
sensor -> 
wrong Input -> 