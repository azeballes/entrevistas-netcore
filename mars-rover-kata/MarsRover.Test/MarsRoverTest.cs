using NUnit.Framework;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        private MarsRover _mars;
        
        [SetUp]
        public void Setup(){
            _mars = new MarsRover();
        }
        
        [Test]
        [Ignore("wip")]
        public void InitialPosition()
        {
            /*Posicion inicial es x=0, y=0, d='N'*/
        }

        [Test]
        [Ignore("wip")]
        public void MoveForward()
        {
            /*Enviar el comando 'F' al Rover. Entonces la posición es x=0, y=1, f='N'*/
        }

        [Test]
        [Ignore("wip")]
        public void MoveBackward()
        {
            /*Enviar el comando 'B' al Rover. Entonces la posición es x=0, y=-1, f='N'*/
        }

        [Test]
        [Ignore("wip")]
        public void TurnLeft()
        {
            /*Enviar el comando 'L' al Rover. Entonces la posición es x=0, y=0, f='W'*/
        }

        [Test]
        [Ignore("wip")]
        public void TurnRight()
        {
            /*Enviar el comando 'R' al Rover. Entonces la posición es x=0, y=0, f='E'*/
        }

        [Test]
        [Ignore("wip")]
        [TestCase("FB", 0, 0, 'N')]
        [TestCase("FRF", 1, 1, 'E')]
        [TestCase("BLF", -1, -1, 'W')]
        [TestCase("FRB", -1, 1, 'E')]        
        [TestCase("RFLB", 1, -1, 'N')]
        public void ChainOfCommands(string command, int x, int y, char facing){
            /*Procesar las cadenas de comandos y verificar la posición final del Rover*/
        }
    }
}