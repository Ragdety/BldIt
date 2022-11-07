using System;
using Xunit;

namespace BldIt.Lang.Test;

public class UnitTest1
{
    [Fact]
    public void TestVariableDeclaration()
    {
        var code = @"
            x = 1;
            y = 2
            z = x + y;";
        
        throw new NotImplementedException();
    }
    
    private static void InitParser()
    {
        //Initialize BldItParser here
        //Return the parser to visit the file using BldItVisitor
        //TODO: Move this into a super class, initialize in constructor maybe?
    }
}