using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using MathClubTracker.NHibernate.Services;
// <copyright file="StudentServiceTest.ConstructorTest.g.cs">Copyright ©  2013</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace MathClubTracker.NHibernate.Services.Tests
{
    public partial class StudentServiceTest
    {

[TestMethod]
[PexGeneratedBy(typeof(StudentServiceTest))]
[PexRaisedException(typeof(ArgumentNullException))]
public void ConstructorTestThrowsArgumentNullException269()
{
    StudentService studentService;
    studentService = this.ConstructorTest((ISession)null);
}
    }
}
