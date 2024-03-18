# Weasel-Server
## setup
# ip adress
ReadIPFromText.txt is used to bind the ip address to the corresponding port, by default this is 9999. Firewall settings have to be set accordingly for the service to be avaible.

# admin
To make the REST API available in the network. You need to start the program with administrator permissions.

## start file
# HTL Wolfsberg
weasel create real MC6-false-39-LightBlue
weasel create real AV002-false-48-LightYellow
weasel create real AV015-false-46-LightRed
kuka real

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

### kuka virtual/real
used to set the kuka in simulation or in real mode. At start this setting is set so simulation

### map show
used to show the weasel map

## map reserve
used to reserve a point on the map

## sensor
used to virtually touch the sensor