using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame
{
	public class Main : MonoBehaviour
	{
		public FlashLightController FlashLightController { get; private set; }
		public InputController InputController { get; private set; }
		public PlayerController PlayerController { get; private set; }
		public WeaponController WeaponController { get; private set; }
		public SelectionController SelectionController { get; private set; }
		public BotController BotController { get; private set; }
		public ObjectManager ObjectManager { get; private set; }
		private BaseController[] Controllers;

		public Transform Player { get; private set; }
		public Transform MainCamera { get; private set; }

		public static Main Instance { get; private set; }
		public Bot RefBotPrefab;
        public Kit RefKitPrefab;
        public Mina RefMinaPrefab;
        public Respawner Respawner;
        public int CountBot;
        public int CountKit;

		private void Awake()
		{
			Instance = this;

			MainCamera = Camera.main.transform;
			Player = GameObject.FindGameObjectWithTag("Player").transform;

			ObjectManager = new ObjectManager();
			
			PlayerController = new PlayerController(new UnitMotor(Player));
			
			FlashLightController = new FlashLightController();
			InputController = new InputController();
			SelectionController = new SelectionController();
			WeaponController = new WeaponController();

			BotController = new BotController();
            Respawner = new Respawner();


			Controllers = new BaseController[7];
			Controllers[0] = FlashLightController;
			Controllers[1] = InputController;
			Controllers[2] = PlayerController;
			Controllers[3] = WeaponController;
			Controllers[4] = SelectionController;
			Controllers[5] = BotController;
            Controllers[6] = Respawner;

        }

		private void Start()
		{
            ObjectManager.Start();
			InputController.On();
			PlayerController.On();
			BotController.On();
			BotController.Init(CountBot);
            Respawner.InitKit(CountKit);
            Respawner.InitMina(CountKit);
        }

		private void Update()
		{
			for (var index = 0; index < Controllers.Length; index++)
			{
				var controller = Controllers[index];
				controller.OnUpdate();
			}
		}
		private void OnGUI()
		{
			GUI.Label(new Rect(0, 0, 100, 100), $"{1 / Time.deltaTime:0.0}");
		}
	}
}