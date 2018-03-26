**解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。**
区别：游戏对象其实本身并没有什么属性，相当于一个空容器，容纳各个组件，属性。资源就是游戏资源，游戏中使用到的图片，音频，场景，预设，脚本等都是资源，形如文件形式被应用到游戏当中。联系：游戏对象与资源一起配合实现游戏。
 
**分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）**
游戏对象树与资源的组织结构都类似计算机中的文件系统目录结构，而游戏对象树的根目录就是一个个对象，其子目录就是一个个子对象，子对象的行为跟随主对象。
 
![](https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1522685106&di=ac208ab5ad89f5f0518663e7f35a0adb&imgtype=jpg&er=1&src=http%3A%2F%2Fimg.bitscn.com%2Fupimg%2Fallimg%2Fc141118%2F1416321061C1Z-25594.jpg)

**编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件**
  
  1.基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
  
  答：
  
  ```
  void Awake () {  
        Debug.Log("Awake");  
        enabled = false;  
    } 
    //初始化函数，在游戏开始时系统自动调用。一般用来创建变量之类的东西。 
  ```
  ```
  void Start () {  
        Debug.Log("Start");  
    }
    //初始化函数，在所有Awake函数运行完之后（一般是这样，但不一定），在所有Update函数前系统自动调用。一般用来给变量赋值。 
  ```
  ```
  void Update ()
    {
        Debug.Log("Update time :" + Time.deltaTime);
    }
    // 只要处于激活状态下的脚本，都会在每一帧里调用Update()函数，该函数也是最为常用的一个函数，用来更新逻辑。
    //当MonoBehaviour启用时，其Update在每一帧被调用，约每0.016s刷新一次
 
  void FixedUpdate (){
        Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }
    //该函数用于固定更新。在游戏运行的过程中，每一帧的处理时间是不固定的，当我们需要固定间隔时间执行某些代码时用到，固定0.02s刷新一次
  ```
  ```
  void LateUpdate(){
             Debug.Log(this.name + "'s LateUpdate()");
     }
     //该函数是延迟更新函数，处于激活状态下的脚本在每一帧里都会在Update()函数执行后调用该函数，通常用来调整代码执行的顺序，约0.016s刷新一次
  ```
  
  2.常用事件包括 OnGUI() OnDisable() OnEnable()
  
  答：
  
  ```
  void OnGUI(){
		Debug.Log("OnGUI time :" + Time.deltaTime);
	}
  //刷新时间不固定，有时约0.02s，有时约0.12，有快有慢
  ```
  
