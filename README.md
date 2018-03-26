**解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。**
区别：游戏对象其实本身并没有什么属性，相当于一个空容器，容纳各个组件，属性。资源就是游戏资源，游戏中使用到的图片，音频，场景，预设，脚本等都是资源，形如文件形式被应用到游戏当中。联系：游戏对象与资源一起配合实现游戏。
 
**分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）**
游戏对象树与资源的组织结构都类似计算机中的文件系统目录结构，而游戏对象树的根目录就是一个个对象，其子目录就是一个个子对象，子对象的行为跟随主对象。
 
![](https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1522685106&di=ac208ab5ad89f5f0518663e7f35a0adb&imgtype=jpg&er=1&src=http%3A%2F%2Fimg.bitscn.com%2Fupimg%2Fallimg%2Fc141118%2F1416321061C1Z-25594.jpg)

**编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件**


  
  1.基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
  
  答：
  
```C# 
  void Awake () {  
	Debug.Log("Awake");  
	enabled = false;  
   } 
    //初始化函数，在游戏开始时系统自动调用。一般用来创建变量之类的东西。 

   void Start () {  
	Debug.Log("Start");  
   }
    //初始化函数，在所有Awake函数运行完之后（一般是这样，但不一定），在所有Update函数前系统自动调用。一般用来给变量赋值。 
    
  void Update ()
    {
        Debug.Log("Update time :" + Time.deltaTime);
    }
    /*只要处于激活状态下的脚本，都会在每一帧里调用Update()函数，该函数也是最为常用的一个函数，用来更新逻辑。
    当MonoBehaviour启用时，其Update在每一帧被调用，约每0.016s刷新一次*/
 
  void FixedUpdate (){
        Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }
    //该函数用于固定更新。在游戏运行的过程中，每一帧的处理时间是不固定的，当我们需要固定间隔时间执行某些代码时用到，固定0.02s刷新一次
    
  void LateUpdate(){
             Debug.Log(this.name + "'s LateUpdate()");
     }
     //该函数是延迟更新函数，处于激活状态下的脚本在每一帧里都会在Update()函数执行后调用该函数，通常用来调整代码执行的顺序，约0.016s刷新一次
```     
  
  2.常用事件包括 OnGUI() OnDisable() OnEnable()
  
  答：
  
```C#  
   void OnGUI(){
		Debug.Log("OnGUI time :" + Time.deltaTime);
	}
  //刷新时间不固定，有时约0.02s，有时约0.12，有快有慢
  
  void OnEnable()
	{
		Debug.Log("OnEnable");
	}
  //当场景启动完毕是函数运行
 
	void OnDisable()
	{
		Debug.Log("OnDisable");
	}
  //当关闭场景启动时函数执行
```  

**查找脚本手册，了解 GameObject，Transform，Component 对象**

1.分别翻译官方对三个对象的描述（Description）
 
（1）GameObjects: GameObjects are the fundamental objects in Unity that represent characters, props and scenery.

游戏对象是在 Unity 中代表任务，道具和场景的基础对象
 
（2）Tranform: The Transform component determines the Position, Rotation, and Scale of each object in the scene.

变化组件决定了场景中游戏对象的位置，大小和旋转关系。
 
（3）Component: Components are the nuts & bolts of objects and behaviors in a game.

组件是游戏对象和其对应行为之间的枢纽。

 
2.描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
 
![](https://xwy27.github.io/Unity-3d/%E5%9F%BA%E7%A1%80%E6%A6%82%E5%BF%B5/example.png)
	
   ①本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。
   
   答：table 对象(实体)的属性： layer（Default）和tag（Untagged）；table 的 Transform 的属性：Position: (0, 0, 0)，Rotation: (0, 0, 0)，Scale : (1, 1, 1)；table 的 部件：Transform，Mesh filter，Box Collider。
   

 3.用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本出图）略
 
 **整理相关学习资料，编写简单代码验证以下技术的实现：**
 
 1.查找对象：
 
①通过对象名称（Find方法）

②通过标签获取单个游戏对象（FindWithTag方法）

③通过标签获取多个游戏对象（FindGameObjectsWithTags方法）

④通过类型获取单个游戏对象（FindObjectOfType方法）

⑤通过类型获取多个游戏对象（FindObjectsOfType方法）
 
```C#
var cubeF = GameObject.Find("/CubeFather");  
if (null != cubeF)  
{  
    Debug.Log("find cube father~");  
}  
cubeF = GameObject.Find("CubeFather");  
if (null != cubeF)  
{  
    Debug.Log("find cube father, no /~");  
}  
  
var cubeS = GameObject.Find("/CubeFather/CubeSon");  
if (null != cubeS)  
{  
    Debug.Log("find cube son~");  
}  
cubeS = GameObject.Find("CubeFather/CubeSon");  
if (null != cubeS)  
{  
    Debug.Log("find cube son, no /~");  
}  
cubeS = GameObject.Find("CubeSon");  
if (null != cubeS)  
{  
    Debug.Log("find cube son, no one /~");  
}  
```
 
2.添加子对象:

```C#
GameObject.CreatePrimitive(PrimitiveType);
```

3.遍历对象树:

```C#
foreach (Transform child in transform)
{
    Debug.Log(child.gameObject.name);
}
```

4.清除所有子对象:

```C#
foreach(Transform child in transform) {
   Destroy(child.gameObject);
}
```
 
**资源预设（Prefabs）与 对象克隆 (clone)**
 
1.预设（Prefabs）有什么好处？预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
 
答：预设是Unity中的一种特殊资源。一般来说预设就是一个或者一系列组件的集合体，你可以在创建了预设以后，对预设进行实例化。当预设发生改变是，这些更改将应用于所有与之链接的实例。所以预设省去大量的重做工作。
 
对象克隆，就是直接新克隆了一个原有对象的实例，与源对象无太大联系。
 
2.制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象

```C#
public class NewBehaviourScript : MonoBehaviour {
    private string prePath = "prefabs/table";
    // Use this for initialization
    void Start () {
        GameObject Table =
            Instantiate(Resource.Load(prePath), new Vector(4, 0, 0), Quaternion.identity) as GameObject;
    }
}
```

**尝试解释组合模式（Composite Pattern / 一种设计模式）。使用 BroadcastMessage() 方法向子对象发送消息**
 
答：
 
![](https://images2015.cnblogs.com/blog/974944/201703/974944-20170312003459311-1568701562.png)

 
父类：

```C#
public class ParentBehaviourScript : MonoBehaviour {
   // Use this for initialization
   void Start () {
       this.BroadcastMessage("Test");
   }
}
```
 
子类：

```C#
public class ChildBehaviourScript : MonoBehaviour {
    void Test() {
        Debug.Log("Child Received");
    }
}
```
