using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;

namespace MiniUnity
{

    public class Game: GameObject
    {
        public Game()
        {
            Orchestrator = new UpdateOrchestrator();

            FramesPerSec = 25;
            IsOver = false; // 
        }

        public bool IsOver { get; set; } //= false;


        /// <summary>
        /// � ����, ��������, ������ ���� ���� �� ���� �����.
        /// ��������, ������ ������� ������ ���� - �� ���� ��� �� ��������, ��� � ���� ��������. ������� �� �����.
        /// </summary>
        protected Scene Scene
        {
            get => scene;
            set
            {
                if (value != null)
                {
                    scene = value;
                    // ��� ������� ����� � ���� ����� ��������� ���� ���� ��� ��������.
                    scene.Parent = this;
                }
                else // value=null
                {
                    // ��� �������� ����� ������� ��������
                    if (scene != null) scene.Parent = null;
                }
            }
        }

        protected Scene scene;



        //public void Finish()
        //{
        //    IsOver = true;
        //}

        #region ��������� ����

        /// <summary>  ���������� ������ � �������
        /// </summary>
        public int FramesPerSec
        {
            get { return Orchestrator.FramesPerSec;}
            set { Orchestrator.FramesPerSec = value; }
        }


        #endregion


        #region ������ � ��� �������

        // ��� ������ ������������ � ������� ����� �� �������� �� ����� ���������� ����� ��������� ������������ - 
        // ������, ����� IOContainer, ��� ����� ����������� � ����� ��������� ����������� ����.
        public UpdateOrchestrator Orchestrator; // = new UpdateOrchestrator();

        #endregion

        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// ����������, ���������� ����.
        /// </summary>
        /// <remarks>
        /// ���� ���������, ��� ��� ���� ����� ������.
        /// ������� ���� � ������ ��-��������, ���������� ������ ���� �����, ���� � ����� ��������� ����� �������.
        /// </remarks>
        public void Play(Game game, Scene scene)
        {
            // �� ����, ��� �� ����������� ���� ��� ���������, ���� ����� ������ ���� � ���������. ������???
            if (Scene == null) throw new NullReferenceException("�� ���������� ������������ ����");

            game.IsOver = false;
            scene.IsOver = false;

            Orchestrator.Start();
            Scene.Start();
            
            // �������� ���� ���������� ��� ����������� Orchestrator;
            // � ����� �������� scene.Update()
            // ������ ���� �� ����� ���������� ���� ��������� ���� ��� ���������� �����
            // ����� ���� �� ������� ��� ���:
            // Orchestrator.DoUpdates(scene.Update, (()=> game.IsOver || Scene.IsOver));
            // ��, ���� �� ��������� � ������ ������ ������ ����, ������� ������� � ������� �� ����:
            Orchestrator.DoUpdates(scene.Update, CycleIsOver);

            // ��������� ������� - � C# ����� ������ ��������, �� ����� ������������
            bool CycleIsOver()
            {
                var result = game.IsOver || Scene.IsOver;
                return result;
            }

        }

        public void Play()
        {
            Play(this, Scene);
        }

    }


    public class Scene: GameObject
    {
        public override void Start()
        {
            IsOver = false;
            // ���������� ��������� ��������� ���� �������� �����
            base.Start();
        }

        /// <summary>
        /// �������� ������. 
        /// ��� ����������� ���������, ��� ������������ ���������, ��� �.�.
        /// </summary>
        public override void Update()
        {
            //foreach (var child in Children)
            //{
            //    child.Update();
            //}
            
            base.Update();
        }

        public bool IsOver { get; set; }
    }


    /// <summary>
    /// �������� ����� ��� ���� ��������, �� ������� �������� ����
    /// </summary>
    public class GameObject
    {

        /// <summary>
        /// ������������ ������
        /// </summary>
        public GameObject Parent { get; set; }

        /// <summary>
        /// ��������� �������, ������������� ��������
        /// </summary>
        protected List<GameObject> Children = new List<GameObject>();

        #region // ������� ���������� � ������ ��������

        /// <summary>
        /// ����� � ���������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public GameObject GetParentComponent<T>()
        {
            GameObject result = null;
            if (Parent == null) return null;
            var parentType = Parent.GetType();
            if ((parentType == typeof(T))
                ||
                (parentType.IsSubclassOf(typeof(T))))
                return Parent;

            return Parent.GetParentComponent<T>();
        }

        // ��� ���������� ���������� � ���� ��������������� �������� Parent = this
        public void AddComponent(GameObject gameObject)
        {
            Children.Add(gameObject);
            gameObject.Parent = this;
        }
        public void RemoveComponent(GameObject gameObject)
        {
            Children.Remove(gameObject);
            gameObject.Parent = null;
        }

        /// <summary>
        /// ����� � ����������� �������� ������ ���������� ���� (��� ��� �������)
        /// ������������ ������ ��������� ���������� ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public GameObject GetComponent<T>()
        {
            // ��� ���� ������ ������ ����� ������� ����������� �������� ������ ���� � ������,
            // ������� � ����������� LINQ, ���� ��� ���������� �������� ������ �� ������� ������ ��������� )))
            var result = Children?.FirstOrDefault(b => (b.GetType() == typeof(T)) || (b.GetType().IsSubclassOf(typeof(T))) );
            return result;
        }

        /// <summary>
        /// ����� � ����������� �������� ��� ������� ���������� ���� (��� ��� �������)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ICollection<GameObject> GetComponents<T>()
        {
            // ���� LINQ
            var result = Children?
                .Where(b => (b.GetType() == typeof(T)) || (b.GetType().IsSubclassOf(typeof(T))))
                .ToList();
            return result;
        }

        /// <summary>
        /// ����� � ����������� �������� ��������� ���������� ���� (��� ��� �������)
        /// ������������ ������ ��������� ���������� ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public BehaviorComponent GetBehavior<T>()
            where T:BehaviorComponent
        {
            // ��� ���� ������ ������ ����� ������� ����������� �������� ������ ���� � ������,
            // ������� � ����������� LINQ, ���� ��� ���������� �������� ������ �� ������� ������ ��������� )))
            var result = Children?.FirstOrDefault(b => (b.GetType() == typeof(T)) || (b.GetType().IsSubclassOf(typeof(T))) );
            return result as BehaviorComponent;
        }

        /// <summary>
        /// ����� � ����������� �������� ��� �������-��������� ���������� ���� (��� ��� �������)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ICollection<BehaviorComponent> GetBehaviors<T>()
        {
            // ���� LINQ
            var result = Children?
                .Where(b => (b.GetType() == typeof(T)) || (b.GetType().IsSubclassOf(typeof(T))))
                .Select(b => b as BehaviorComponent)
                .ToList();
            return result;
        }

        #endregion


        /// <summary>
        /// ���������� ��� ������ ��������� ��� �����, ����� ����, ��� ��� �������� ��� �������
        /// </summary>
        public virtual void Start()
        {
            foreach (GameObject c in Children)
            {
                c.Start();
                if (OnStart != null) OnStart(this);
            }
        }


        /// <summary>
        /// �������� ������. 
        /// ��� ����������� ���������, ��� ������������ ���������, ��� �.�.
        /// </summary>
        public virtual void Update()
        {
            foreach (GameObject c in Children)
            {
                c.Update();
                if (OnUpdate != null) OnUpdate(this);
            }
        }

        /// <summary>
        /// ������� ���������� ��� ������������� ������� ����
        /// </summary>
        public event OnStartHandler  OnStart;

        /// <summary>
        /// ������� ���������� ��� ���������� ��������� ������� ����
        /// </summary>
        public event OnUpdateHandler  OnUpdate;

        public delegate void OnStartHandler(GameObject gameObject);
        public delegate void OnUpdateHandler(GameObject gameObject);

    }

    /// <summary>
    /// ��������� ���������.
    /// ��� ������ "�������" ��������� ������� ����� �������� ���� ���������.
    /// ������ �������������� ���������� (Component) ��� ������������ � 1994 ����, 
    /// � ����� �Design Patterns: Elements of Reusable Object-Oriented Software�, 
    /// ���������� ������� ��������. 
    /// �������� ���� ������� ���������� ����������� � ����������� ��������� ������� � ������ � ����� ����� 
    /// � � �� �� ����� � ���������� ������� ������ ��� ����� ����� ��������� � ����������������������.
    /// ������, ������� ���������� � Delphi � VisualBasic, ��������� ��.1995
    /// </summary>
    public class BehaviorComponent : GameObject{}



    /// <summary>
    /// ������� ����������. 
    /// �������� �� ��� ������� � ����, ����� ���������� � �.�.
    /// </summary>
    /// <remarks>
    /// (1)
    /// �� ������������� �������� ���� ���������� ����� (IClock),
    /// �� ��� ���� ��������� �������� ���������� ����� - ��������, �� ����� ������ ����, ��� ����� �������, ��� �.�.
    /// (2)
    /// ��������� ���������� ��� � �����, ��������� � ������� ���������� ����������.
    /// ��������� ��������� ������� ������ ���������� �������.
    /// (3)
    /// ������ ���� ������ �������� �� ����� ����������.
    /// � ������������ � ������������� ��������� "��������������� ��������":
    /// ���������� ������ ���� �������� �� ��� ������, ������� ����� ��� ����������� ���������� ��� ��� ����������.
    /// ������� �� ����� �����, ����� (�� �������� �������) ���� ��������� ��������� ����������, 
    /// �, ��������������, ������� ������ �������� ������� � ����� �������. 
    /// </remarks>
    public class UpdateOrchestrator: IClock
    {
        public UpdateOrchestrator()
        {
            Clock = new Clock();
        }

        /// <summary>
        /// ���� - �������� ������� �����
        /// </summary>
        public IClock Clock { get; set; }

        /// <summary>
        /// ������� ������� �����
        /// </summary>
        /// <returns></returns>
        public DateTime Now()
        {
            return Clock.Now();
        }

        public void SetDateTime(DateTime dateTime)
        {
            if (!Stopped) throw new NotSupportedException("��������� ������� �������� ������ ��� ������������� �����");
            Clock.SetDateTime(dateTime);
            // �������� ������ ���������� �������
            LastUpdateTime = dateTime;
            TimeDeltaFromLastUpdate = TimeSpan.Zero;
            TimeDeltaFromLastUpdateInSeconds = 0;
        }

        /// <summary>
        /// ������ ����������� ���������� (� ������� �������)
        /// </summary>
        public DateTime LastUpdateTime { get; protected set; }
        
        /// <summary>
        /// ������ ������ �������� ���������� (� ������� �������)
        /// </summary>
        public DateTime CurrentUpdateTime { get; protected set; }

        /// <summary>
        /// ���������� �������, ��������� � ����������� ����������
        /// </summary>
        public TimeSpan TimeDeltaFromLastUpdate { get; protected set; }
        /// <summary>
        /// ���������� �������, ��������� � ����������� ���������� - � ��������
        /// </summary>
        public float TimeDeltaFromLastUpdateInSeconds { get; protected set; }

        /// <summary>
        /// ������� ������� - ������� ������ �� �������� �������
        /// </summary>
        public float GameTimeScale
        {
            get { return Clock.GameTimeScale;}
            set { Clock.GameTimeScale = value; }
        }





        #region ����/������� �����
        /// <summary>
        /// ���������� ������� �����
        /// </summary>
        public void Stop()
        {
            Clock.Stop();
        }

        /// <summary>
        /// ��������� ������ ������� ������
        /// </summary>
        public void Resume()
        {
            Clock.Resume();
        }


        public bool Stopped
        {
            get { return Clock.Stopped; }
        }
        #endregion

        public void Start()
        {
            CurrentUpdateTime = Now();
            LastUpdateTime = CurrentUpdateTime;
            TimeDeltaFromLastUpdate = TimeSpan.Zero;
            TimeDeltaFromLastUpdateInSeconds = 0;
        }

        /// <summary>
        /// ������� ���������� ���� �������� ����
        /// </summary>
        /// <remarks>
        /// ��������� ������ ���������� � ���� � ������� ����, �� ����� ���������� ������ �������� ������������� � ���� ����� ������� OnUpdate().
        /// ��� ������� ��������� �� Action - �.�. ��������� ��� ����������.
        /// ���� ����� ��������� ������� ������ �������� ����������.
        /// ����� ���� ��������� ��������� �������� �� ������ �������.
        /// </remarks>
        public void Update(UpdateFunc updateFunctionCall)
        {
            // ��������� ����� � ���������� ����������
            CurrentUpdateTime = Now();
            TimeDeltaFromLastUpdate = CurrentUpdateTime - LastUpdateTime;
            TimeDeltaFromLastUpdateInSeconds = (float)TimeDeltaFromLastUpdate.TotalSeconds;
            
            // �������� ����������
            updateFunctionCall();
            //if (OnUpdate != null)
            //    OnUpdate();
            
            // ���������� ����� ���������� ����������
            LastUpdateTime = CurrentUpdateTime;
            TimeDeltaFromLastUpdate = TimeSpan.Zero;
            TimeDeltaFromLastUpdateInSeconds = 0;
        }

        
        /// <summary>
        /// ������� ����������.
        /// ��� ������ ���������� ������� ������� ������������� �� ��� �������, ��������� � ���� ���� ��������� ����������.
        /// </summary>
        public event Action OnUpdate;


        /// <summary>
        /// ������� ������ ���������� - ������ � �������
        /// </summary>
        public int FramesPerSec { get; set; }


        /// <summary>
        /// ���� ���������� �������� ����.
        /// ���������� �� ����.
        /// </summary>
        /// <remarks>
        /// �������� ���������� ������ ������ Orchestrator, 
        /// ������ ��� �� �����, ����� ������� ��������� ����������, 
        /// � ��� ���� ����� �����������, ����� ���� ����������, ������� ������� ������ ����� ���� - 
        /// � ����� �������� ��� ���������� ����������� ��������.
        /// �� ��� ���� �� �� �����, ��� ������ ����� ������. ������� "��� ������" - �������� ��� ����������.
        /// �� ����� ������ �����, ����� ��������� ����������.
        /// ������� ��������� ��� ��������, ������������ ���.
        /// </remarks>
        /// <remarks>
        /// ����� � ���:
        /// public void DoUpdates(Action updateFunctionCall, Func<bool> hasFinished) 
        /// �� �� ������� ����������� ��� ����������
        /// </remarks>
        public void DoUpdates(UpdateFunc updateFunctionCall, HasFinishedFunc hasFinished) 
        {
            while (!hasFinished())
            {
                // �������� ���������� ��������
                //updateFunctionCall();
                Update(updateFunctionCall);
                // ������� ������� ���������� ����������, �� ��� ����� ������ ��������� ������������ �������
                Thread.Sleep(1000/FramesPerSec);
            }
        }

        public delegate void UpdateFunc();

        public delegate bool HasFinishedFunc();
    }



    /// <summary>
    /// ����, ������������� ������� �����.
    /// �.�. ���� ����� ���� �����������, � �� ��� ����� � ��� ������ �� ����������.
    /// ����� ����, ��� ����� ������ ������� �������.
    /// </summary>
    public class Clock : IClock
    {
        /// <summary>
        /// ������� ������� ����� � ������� DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime Now()
        {
            if (_stopped) return LastGameTime;

            CurrentRealTime = DateTime.Now;
            
            // ����� ������� �������
            TimeSpan RealTimeDelta = CurrentRealTime - LastRealTime;
            var gameTimeAdditionMSec = RealTimeDelta.TotalMilliseconds * GameTimeScale;
            TimeSpan GameTimeDelta = TimeSpan.FromMilliseconds(gameTimeAdditionMSec);

            CurrentGameTime = LastGameTime + GameTimeDelta;
            // �������� �������� ������� ��� ���������� �������������
            LastGameTime = CurrentGameTime;
            LastRealTime = CurrentRealTime;
            return CurrentGameTime;
        }

        public void SetDateTime(DateTime dateTime)
        {
            if (!Stopped) throw new NotSupportedException("��������� ������� �������� ������ ��� ������������� �����");
            LastGameTime = dateTime;
        }

        #region ������� �������
        /// <summary>
        /// ������� ����� ������� �������� � �������� - ������� ������� ������ �������� �� ���� �������� �������
        /// </summary>
        public float GameTimeScale { get; set; } = 1;
        #endregion

        #region ����/������� �����
        /// <summary>
        /// ���������� ������� �����
        /// </summary>
        public void Stop()
        {
            _stopped = true;
            // ��������� � �������� ������� ������� �����
            LastRealTime = DateTime.Now;
            LastGameTime = Now();
        }

        /// <summary>
        /// ��������� ������ ������� ������
        /// </summary>
        public void Resume()
        {
            _stopped = false;
            // � ����� ������� ������ ���� ��������� ������� 
            // ������� ������� ����� �������� ����������, 
            // � ��������� �������� ����� �� �������, ���� ������� �� ����:
            LastRealTime = DateTime.Now;
        }

        private DateTime CurrentRealTime;
        private DateTime CurrentGameTime;
        private DateTime LastRealTime;
        private DateTime LastGameTime;

        private bool _stopped = false;

        /// <summary>
        /// ���� �����������?
        /// </summary>
        public bool Stopped
        {
            get { return _stopped; }
        }

        #endregion    
    }

        public interface IClock
    {
        /// <summary>
        /// ������� ������� ����� � ������� DateTime
        /// </summary>
        /// <returns></returns>
        DateTime Now();

        void SetDateTime(DateTime dateTime);

        /// <summary>
        /// ������� ������� - ������� ������ �� �������� �������
        /// </summary>
        float GameTimeScale { get; set; }
        

        /// <summary>
        /// ���������� ������� �����
        /// </summary>
        void Stop();

        /// <summary>
        /// ��������� ������ ������� ������
        /// </summary>
        void Resume();
        
        /// <summary>
        /// ���� �����������?
        /// </summary>
        bool Stopped { get; }

    }
}
