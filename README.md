# TriggerManager
对Quartz的简单封装，实现定时任务功能
使用方法：
1.调用TriggerManager有参构造函数，创建触发器管理器。
  参数是一个委托，该委托就是你定时要执行的代码
2.调用管理器的AddTrigger方法添加触发器
只需以上两步，就可以让你的定时代码在你设定的时间乖乖执行；你设定的时间是AddTrigger的一个参数，在你添加一个触发器的时候传进去的。具体调
用代码的时候自己看就行了。
