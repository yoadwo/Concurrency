// See https://aka.ms/new-console-template for more information

Console.WriteLine("\nBEGIN TEST 1\n");
await test1Async();

Console.WriteLine("\nBEGIN TEST 2\n");
await test2Async();

Console.WriteLine("\nBEGIN TEST 3\n");
//await test3Async();

Console.WriteLine("\nBEGIN TEST 4\n");
//await test4Async();

// per each task
// task is called, and awaited, and execution is sequential
async Task test1Async()
{
    Console.WriteLine("before call func1");
    var f1 = await func1();
    Console.WriteLine("after call func1");

    Console.WriteLine("before call func2");
    var f2 = await func2();
    Console.WriteLine("after call func2");

    Console.WriteLine("value of f1: {0}", f1);
    Console.WriteLine("value of f2: {0}", f2);
}

// per each function
// function is called, but not awaited
// hence the returned value is always the task, not the actual result
// the caller function continues the execute
// in the callee, "end function1", "end function2", following the "await" line are not executed
async Task test2Async()
{
    Console.WriteLine("before call func1");
    var f1 = func1();
    Console.WriteLine("after call func1");

    Console.WriteLine("DoIndependentWork();");

    Console.WriteLine("before call func2");
    var f2 = func2();
    Console.WriteLine("after call func2");

    //int f1res = await f1;
    //int f2res = await f2;

    Console.WriteLine("value of f2: {0}", f2.Status);
    Console.WriteLine("value of f1: {0}", f1.Status);
    //Console.WriteLine("value of f1: {0}", f1res);
}

async Task test3Async()
{
    Console.WriteLine("before call func1");
    var f1 = func1();
    Console.WriteLine("after call func1");

    Console.WriteLine("before call func2");
    var f2 = func2();
    Console.WriteLine("after call func2");
}



async Task<int> func1()
{
    Console.WriteLine("begin function 1");
    var s = await innerfunc("f1");
    Console.WriteLine("end function 1");
    return 1 + Int32.Parse(s);
}

async Task<int> func2()
{
    Console.WriteLine("begin function 2");
    await Task.Delay(2500);
    Console.WriteLine("end function 2");
    return 2 + Int32.Parse("5");
}

async Task test4Async()
{
    Console.WriteLine("before call blocking async");
    var i = await blockingAsync();
    Console.WriteLine("before after blocking async");
    Console.WriteLine("i equals " + i);
}

async Task<string> innerfunc(string callerid)
{
    Console.WriteLine("called from " + callerid);
    await Task.Delay(750);
    return await Task.Run( () => "5");
}

Task<int> blockingAsync()
{
    return Task.Run(() => {
        Console.WriteLine("calling blocking async");
        return blocking();
    });
}

int blocking()
{
    Console.WriteLine("calling blocking");
    Thread.Sleep(1000);
    return 5;
}
