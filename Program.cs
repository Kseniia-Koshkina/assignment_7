namespace assignment_7
{
    internal class Program
    {
        class RemoteController // Invoker class to execute commands
        {
            List<Command> commands = new List<Command>();
            public void setCommand( Command new_command) => commands.Add(new_command);
            public void buttonPressed(int key) => commands[key].execute();
            // 
            public void setOfCommandDisplay()
            {
                for (int i = 0; i < commands.Count(); i++)
                {
                    Console.WriteLine("Key {0} - {1}",i, commands[i].get_command_info());
                }
                Console.WriteLine("Ctr+C - exit");
            }
        }
        interface Command
        {
            void execute();
            string get_command_info();
        }

        class LightOnCommand : Command
        {
            Light light;
            string command_info = "Turn on lights";
            public string get_command_info()=> command_info;
            public LightOnCommand(Light light) => this.light = light;   
            void turn_on() => this.light.on();
            public void execute() => turn_on();
        }

        class LightOffCommand : Command
        {
            Light light;
            string command_info = "Turn off lights";
            public string get_command_info() => command_info;
            public LightOffCommand(Light light) => this.light = light;
            void turn_off() => this.light.off();
            public void execute() => turn_off();
        }
        class IncreaseThermostat : Command
        {
            Thermostat thermostat;
            string command_info = "Increase thermostat temperature";
            public string get_command_info() => command_info;
            public IncreaseThermostat(Thermostat thermostat) => this.thermostat = thermostat;
            void increase() => this.thermostat.increase();
            public void execute() => increase();
        }
        class DecreaseThermostat : Command
        {
            Thermostat thermostat;
            string command_info = "Decrease thermostat temperature";
            public string get_command_info() => command_info;
            public DecreaseThermostat(Thermostat thermostat) => this.thermostat = thermostat;
            void decrease() => this.thermostat.decrease();
            public void execute() => decrease();
        }
        class Light
        {
            string state = "OFF" ;
            public Light() { }
            public void display() => Console.WriteLine("Light's state is {0}",state);
            public void on()
            {
                this.state = "ON";
                display();
            }
            public void off()
            {
                this.state = "OFF";
                display();
            }
        }
        class Thermostat
        {
            int state = 10;
            public Thermostat() { }
            public void display() => Console.WriteLine("Thermostat's state is {0}", state);
            public void increase()
            {
                this.state += 1;
                display();
            }
            public void decrease()
            {
                this.state -= 1;
                display();
            }
        }


        static void Main(string[] args)
        {
            // IoT devices
            Light bedroom_lights = new Light();
            Thermostat bedroom_thermostat =  new Thermostat();
            // Commands
            LightOnCommand turn_on_light =  new LightOnCommand(bedroom_lights);
            LightOffCommand turn_off_light =  new LightOffCommand(bedroom_lights);
            IncreaseThermostat increase_thermostat = new IncreaseThermostat(bedroom_thermostat);
            DecreaseThermostat decrease_thermostat = new DecreaseThermostat(bedroom_thermostat);

            RemoteController controller = new RemoteController();
            controller.setCommand(turn_on_light);
            controller.setCommand(turn_off_light);
            controller.setCommand(increase_thermostat);
            controller.setCommand(decrease_thermostat);

            controller.setOfCommandDisplay();
            while (true)
            {
                Console.Write("Press button on remote controller: ");
                string key = Console.ReadLine();
                try
                {
                    int button_key = int.Parse(key);
                    controller.buttonPressed(int.Parse(key));
                }
                catch
                {
                    continue;
                }
                
                
            }
        }
    }
}