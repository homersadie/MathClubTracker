using MathClubTracker.NHibernate.Services;
using Iesi.Collections;
using Iesi.Collections.Generic;
using Microsoft.Pex.Framework.Suppression;
// <copyright file="PexAssemblyInfo.cs">Copyright ©  2013</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("MathClubTracker.NHibernate")]
[assembly: PexInstrumentAssembly("MathClubTracker.Domain")]
[assembly: PexInstrumentAssembly("System.Data")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("NHibernate")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "MathClubTracker.Domain")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Data")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "NHibernate")]
[assembly: PexSuppressUninstrumentedMethodFromType(typeof(DictionarySet<>))]
[assembly: PexSuppressUninstrumentedMethodFromType(typeof(HashedSet<>))]
[assembly: PexSuppressUninstrumentedMethodFromType(typeof(HashedSet))]
[assembly: PexSuppressExplorableEvent(typeof(StudentService))]

