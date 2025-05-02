using _2_Task.Modals;

Vehicle car = new Car();
Vehicle motorBike = new Motorbike();
Vehicle boat = new Boat();
Vehicle plane = new Airplane();

VehicleManager.DisplayVehicleInfo(car);
VehicleManager.DisplayVehicleInfo(motorBike);
VehicleManager.DisplayVehicleInfo(boat);
VehicleManager.DisplayVehicleInfo(plane);

Car carObj = (Car)car;
Motorbike motorBikeObj = (Motorbike)motorBike;
Boat boatObj = (Boat)boat;
Airplane planeObj = (Airplane)plane;

Console.WriteLine(" ");

carObj.Drive();
motorBikeObj.Wheelie();
boatObj.Sail();
planeObj.Fly();