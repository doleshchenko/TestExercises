using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class Taxi
    {
        private int maxCapacity = 5;
        private int _maxWeight = 400;
        private int _frontRearPressure = 30;
        private int _backRearPressure = 30;

        public void TakePassengers(List<(string passangerName, int luggageWeight)> passangers, decimal longtitued, decimal latitude, PaymentType pt)
        {
            if (passangers.Count > maxCapacity)
            {
                throw new Exception("Too many passangers");
            }
            var w = 0;
            for (int i = 0; i < passangers.Count; i++)
            {
                var passanger = passangers[i];
                w += passanger.luggageWeight;
            }
            if (w > _maxWeight)
            {
                throw new Exception("Overweight");
            }
            if (passangers.Count > 1 && passangers.Count < 3)
            {
                _frontRearPressure = 35;
                _backRearPressure = 35;
            }
            if (passangers.Count > 3)
            {
                _frontRearPressure = 45;
                _backRearPressure = 45;
            }

            var n = new Navigator();
            var route = n.GetRoute(longtitued, latitude);
            var price = 0;
            if (route.distance < 100)
            {
                price = 50;
            }
            if (route.distance >= 100 && route.distance <= 150)
            {
                price = 75;
            }
            if (route.distance > 150)
            {
                price = 100;
            }
            if (pt == PaymentType.Cash)
            {
                var c = new CacheRegisterMachine();
                c.TakePayment(price);
            }
            if (pt == PaymentType.CreaditCard)
            {
                var terminal = new PaymentTerminal();
                terminal.TakePayment(price);
            }
            Go(route);
        }

        private void Go(Route route)
        {
            
        }
    }

    public class Route
    {
        public int distance;
        public Track track;
    }

    public class Track
    {
    }

    public enum PaymentType
    {
        CreaditCard,
        Cash
    }
    public class PaymentTerminal
    {
        public void TakePayment(int amount)
        {
            throw new NotImplementedException();
        }
    }

    public class CacheRegisterMachine
    {
        public void TakePayment(int amount)
        {
            throw new NotImplementedException();
        }
    }

    public class Navigator
    {
        public Route GetRoute(decimal longtitued, decimal latitude)
        {
            throw new NotImplementedException();
        }
    }
}
