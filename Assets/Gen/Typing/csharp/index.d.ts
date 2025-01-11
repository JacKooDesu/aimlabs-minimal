
    declare namespace CS {
    //keep type incompatibility / 此属性保持类型不兼容
    const __keep_incompatibility: unique symbol;
    interface $Ref<T> {
        __doNoAccess: T
    }
    namespace System {
        interface Array$1<T> extends System.Array {
            get_Item(index: number):T;
            set_Item(index: number, value: T):void;
        }
    }
    type $Task<T> = System.Threading.Tasks.Task$1<T>
    namespace System {
        class Object
        {
            protected [__keep_incompatibility]: never;
            public Equals ($obj: any) : boolean
            public static Equals ($objA: any, $objB: any) : boolean
            public GetHashCode () : number
            public GetType () : System.Type
            public ToString () : string
            public static ReferenceEquals ($objA: any, $objB: any) : boolean
            public constructor ()
        }
        class ValueType extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class Void extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class Int32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        interface IFormattable
        {
        }
        interface ISpanFormattable
        {
        }
        interface IComparable
        {
        }
        interface IComparable$1<T>
        {
        }
        interface IConvertible
        {
        }
        interface IEquatable$1<T>
        {
        }
        class Boolean extends System.ValueType implements System.IComparable, System.IComparable$1<boolean>, System.IConvertible, System.IEquatable$1<boolean>
        {
            protected [__keep_incompatibility]: never;
        }
        class Single extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class String extends System.Object implements System.ICloneable, System.IComparable, System.IComparable$1<string>, System.IConvertible, System.Collections.Generic.IEnumerable$1<number>, System.Collections.IEnumerable, System.IEquatable$1<string>
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICloneable
        {
        }
        class Char extends System.ValueType implements System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class Array extends System.Object implements System.Collections.IStructuralComparable, System.Collections.IStructuralEquatable, System.ICloneable, System.Collections.ICollection, System.Collections.IEnumerable, System.Collections.IList
        {
            protected [__keep_incompatibility]: never;
        }
        class Enum extends System.ValueType implements System.IFormattable, System.IComparable, System.IConvertible
        {
            protected [__keep_incompatibility]: never;
        }
        class Delegate extends System.Object implements System.Runtime.Serialization.ISerializable, System.ICloneable
        {
            protected [__keep_incompatibility]: never;
            public get Method(): System.Reflection.MethodInfo;
            public get Target(): any;
            public static CreateDelegate ($type: System.Type, $firstArgument: any, $method: System.Reflection.MethodInfo, $throwOnBindFailure: boolean) : Function
            public static CreateDelegate ($type: System.Type, $firstArgument: any, $method: System.Reflection.MethodInfo) : Function
            public static CreateDelegate ($type: System.Type, $method: System.Reflection.MethodInfo, $throwOnBindFailure: boolean) : Function
            public static CreateDelegate ($type: System.Type, $method: System.Reflection.MethodInfo) : Function
            public static CreateDelegate ($type: System.Type, $target: any, $method: string) : Function
            public static CreateDelegate ($type: System.Type, $target: System.Type, $method: string, $ignoreCase: boolean, $throwOnBindFailure: boolean) : Function
            public static CreateDelegate ($type: System.Type, $target: System.Type, $method: string) : Function
            public static CreateDelegate ($type: System.Type, $target: System.Type, $method: string, $ignoreCase: boolean) : Function
            public static CreateDelegate ($type: System.Type, $target: any, $method: string, $ignoreCase: boolean, $throwOnBindFailure: boolean) : Function
            public static CreateDelegate ($type: System.Type, $target: any, $method: string, $ignoreCase: boolean) : Function
            public DynamicInvoke (...args: any[]) : any
            public Clone () : any
            public GetObjectData ($info: System.Runtime.Serialization.SerializationInfo, $context: System.Runtime.Serialization.StreamingContext) : void
            public GetInvocationList () : System.Array$1<Function>
            public static Combine ($a: Function, $b: Function) : Function
            public static Combine (...delegates: Function[]) : Function
            public static Remove ($source: Function, $value: Function) : Function
            public static RemoveAll ($source: Function, $value: Function) : Function
            public static op_Equality ($d1: Function, $d2: Function) : boolean
            public static op_Inequality ($d1: Function, $d2: Function) : boolean
        }
        interface MulticastDelegate
        { 
        (...args:any[]) : any; 
        Invoke?: (...args:any[]) => any;
        }
        var MulticastDelegate: { new (func: (...args:any[]) => any): MulticastDelegate; }
        interface Action$1<T>
        { 
        (obj: T) : void; 
        Invoke?: (obj: T) => void;
        }
        interface Func$1<TResult>
        { 
        () : TResult; 
        Invoke?: () => TResult;
        }
        interface Action
        { 
        () : void; 
        Invoke?: () => void;
        }
        var Action: { new (func: () => void): Action; }
        class Exception extends System.Object implements System.Runtime.Serialization.ISerializable, System.Runtime.InteropServices._Exception
        {
            protected [__keep_incompatibility]: never;
        }
        interface IFormatProvider
        {
        }
        interface Converter$2<TInput, TOutput>
        { 
        (input: TInput) : TOutput; 
        Invoke?: (input: TInput) => TOutput;
        }
        interface Predicate$1<T>
        { 
        (obj: T) : boolean; 
        Invoke?: (obj: T) => boolean;
        }
        interface IDisposable
        {
        }
        interface Comparison$1<T>
        { 
        (x: T, y: T) : number; 
        Invoke?: (x: T, y: T) => number;
        }
        class Double extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class ReadOnlySpan$1<T> extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class Span$1<T> extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class Type extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._Type, System.Reflection.ICustomAttributeProvider, System.Reflection.IReflect
        {
            protected [__keep_incompatibility]: never;
            public static Delimiter : number
            public static EmptyTypes : System.Array$1<System.Type>
            public static Missing : any
            public static FilterAttribute : System.Reflection.MemberFilter
            public static FilterName : System.Reflection.MemberFilter
            public static FilterNameIgnoreCase : System.Reflection.MemberFilter
            public get IsSerializable(): boolean;
            public get ContainsGenericParameters(): boolean;
            public get IsVisible(): boolean;
            public get MemberType(): System.Reflection.MemberTypes;
            public get Namespace(): string;
            public get AssemblyQualifiedName(): string;
            public get FullName(): string;
            public get Assembly(): System.Reflection.Assembly;
            public get Module(): System.Reflection.Module;
            public get IsNested(): boolean;
            public get DeclaringType(): System.Type;
            public get DeclaringMethod(): System.Reflection.MethodBase;
            public get ReflectedType(): System.Type;
            public get UnderlyingSystemType(): System.Type;
            public get IsTypeDefinition(): boolean;
            public get IsArray(): boolean;
            public get IsByRef(): boolean;
            public get IsPointer(): boolean;
            public get IsConstructedGenericType(): boolean;
            public get IsGenericParameter(): boolean;
            public get IsGenericTypeParameter(): boolean;
            public get IsGenericMethodParameter(): boolean;
            public get IsGenericType(): boolean;
            public get IsGenericTypeDefinition(): boolean;
            public get IsVariableBoundArray(): boolean;
            public get IsByRefLike(): boolean;
            public get HasElementType(): boolean;
            public get GenericTypeArguments(): System.Array$1<System.Type>;
            public get GenericParameterPosition(): number;
            public get GenericParameterAttributes(): System.Reflection.GenericParameterAttributes;
            public get Attributes(): System.Reflection.TypeAttributes;
            public get IsAbstract(): boolean;
            public get IsImport(): boolean;
            public get IsSealed(): boolean;
            public get IsSpecialName(): boolean;
            public get IsClass(): boolean;
            public get IsNestedAssembly(): boolean;
            public get IsNestedFamANDAssem(): boolean;
            public get IsNestedFamily(): boolean;
            public get IsNestedFamORAssem(): boolean;
            public get IsNestedPrivate(): boolean;
            public get IsNestedPublic(): boolean;
            public get IsNotPublic(): boolean;
            public get IsPublic(): boolean;
            public get IsAutoLayout(): boolean;
            public get IsExplicitLayout(): boolean;
            public get IsLayoutSequential(): boolean;
            public get IsAnsiClass(): boolean;
            public get IsAutoClass(): boolean;
            public get IsUnicodeClass(): boolean;
            public get IsCOMObject(): boolean;
            public get IsContextful(): boolean;
            public get IsCollectible(): boolean;
            public get IsEnum(): boolean;
            public get IsMarshalByRef(): boolean;
            public get IsPrimitive(): boolean;
            public get IsValueType(): boolean;
            public get IsSignatureType(): boolean;
            public get IsSecurityCritical(): boolean;
            public get IsSecuritySafeCritical(): boolean;
            public get IsSecurityTransparent(): boolean;
            public get StructLayoutAttribute(): System.Runtime.InteropServices.StructLayoutAttribute;
            public get TypeInitializer(): System.Reflection.ConstructorInfo;
            public get TypeHandle(): System.RuntimeTypeHandle;
            public get GUID(): System.Guid;
            public get BaseType(): System.Type;
            public static get DefaultBinder(): System.Reflection.Binder;
            public get IsInterface(): boolean;
            public IsEnumDefined ($value: any) : boolean
            public GetEnumName ($value: any) : string
            public GetEnumNames () : System.Array$1<string>
            public FindInterfaces ($filter: System.Reflection.TypeFilter, $filterCriteria: any) : System.Array$1<System.Type>
            public FindMembers ($memberType: System.Reflection.MemberTypes, $bindingAttr: System.Reflection.BindingFlags, $filter: System.Reflection.MemberFilter, $filterCriteria: any) : System.Array$1<System.Reflection.MemberInfo>
            public IsSubclassOf ($c: System.Type) : boolean
            public IsAssignableFrom ($c: System.Type) : boolean
            public GetType () : System.Type
            public GetElementType () : System.Type
            public GetArrayRank () : number
            public GetGenericTypeDefinition () : System.Type
            public GetGenericArguments () : System.Array$1<System.Type>
            public GetGenericParameterConstraints () : System.Array$1<System.Type>
            public GetConstructor ($types: System.Array$1<System.Type>) : System.Reflection.ConstructorInfo
            public GetConstructor ($bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.ConstructorInfo
            public GetConstructor ($bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $callConvention: System.Reflection.CallingConventions, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.ConstructorInfo
            public GetConstructors () : System.Array$1<System.Reflection.ConstructorInfo>
            public GetConstructors ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.ConstructorInfo>
            public GetEvent ($name: string) : System.Reflection.EventInfo
            public GetEvent ($name: string, $bindingAttr: System.Reflection.BindingFlags) : System.Reflection.EventInfo
            public GetEvents () : System.Array$1<System.Reflection.EventInfo>
            public GetEvents ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.EventInfo>
            public GetField ($name: string) : System.Reflection.FieldInfo
            public GetField ($name: string, $bindingAttr: System.Reflection.BindingFlags) : System.Reflection.FieldInfo
            public GetFields () : System.Array$1<System.Reflection.FieldInfo>
            public GetFields ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.FieldInfo>
            public GetMember ($name: string) : System.Array$1<System.Reflection.MemberInfo>
            public GetMember ($name: string, $bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.MemberInfo>
            public GetMember ($name: string, $type: System.Reflection.MemberTypes, $bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.MemberInfo>
            public GetMembers () : System.Array$1<System.Reflection.MemberInfo>
            public GetMembers ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.MemberInfo>
            public GetMethod ($name: string) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $bindingAttr: System.Reflection.BindingFlags) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $types: System.Array$1<System.Type>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $callConvention: System.Reflection.CallingConventions, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $genericParameterCount: number, $types: System.Array$1<System.Type>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $genericParameterCount: number, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $genericParameterCount: number, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.MethodInfo
            public GetMethod ($name: string, $genericParameterCount: number, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $callConvention: System.Reflection.CallingConventions, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.MethodInfo
            public GetMethods () : System.Array$1<System.Reflection.MethodInfo>
            public GetMethods ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.MethodInfo>
            public GetNestedType ($name: string) : System.Type
            public GetNestedType ($name: string, $bindingAttr: System.Reflection.BindingFlags) : System.Type
            public GetNestedTypes () : System.Array$1<System.Type>
            public GetNestedTypes ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Type>
            public GetProperty ($name: string) : System.Reflection.PropertyInfo
            public GetProperty ($name: string, $bindingAttr: System.Reflection.BindingFlags) : System.Reflection.PropertyInfo
            public GetProperty ($name: string, $returnType: System.Type) : System.Reflection.PropertyInfo
            public GetProperty ($name: string, $types: System.Array$1<System.Type>) : System.Reflection.PropertyInfo
            public GetProperty ($name: string, $returnType: System.Type, $types: System.Array$1<System.Type>) : System.Reflection.PropertyInfo
            public GetProperty ($name: string, $returnType: System.Type, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.PropertyInfo
            public GetProperty ($name: string, $bindingAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $returnType: System.Type, $types: System.Array$1<System.Type>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>) : System.Reflection.PropertyInfo
            public GetProperties () : System.Array$1<System.Reflection.PropertyInfo>
            public GetProperties ($bindingAttr: System.Reflection.BindingFlags) : System.Array$1<System.Reflection.PropertyInfo>
            public GetDefaultMembers () : System.Array$1<System.Reflection.MemberInfo>
            public static GetTypeHandle ($o: any) : System.RuntimeTypeHandle
            public static GetTypeArray ($args: System.Array$1<any>) : System.Array$1<System.Type>
            public static GetTypeCode ($type: System.Type) : System.TypeCode
            public static GetTypeFromCLSID ($clsid: System.Guid) : System.Type
            public static GetTypeFromCLSID ($clsid: System.Guid, $throwOnError: boolean) : System.Type
            public static GetTypeFromCLSID ($clsid: System.Guid, $server: string) : System.Type
            public static GetTypeFromProgID ($progID: string) : System.Type
            public static GetTypeFromProgID ($progID: string, $throwOnError: boolean) : System.Type
            public static GetTypeFromProgID ($progID: string, $server: string) : System.Type
            public InvokeMember ($name: string, $invokeAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $target: any, $args: System.Array$1<any>) : any
            public InvokeMember ($name: string, $invokeAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $target: any, $args: System.Array$1<any>, $culture: System.Globalization.CultureInfo) : any
            public InvokeMember ($name: string, $invokeAttr: System.Reflection.BindingFlags, $binder: System.Reflection.Binder, $target: any, $args: System.Array$1<any>, $modifiers: System.Array$1<System.Reflection.ParameterModifier>, $culture: System.Globalization.CultureInfo, $namedParameters: System.Array$1<string>) : any
            public GetInterface ($name: string) : System.Type
            public GetInterface ($name: string, $ignoreCase: boolean) : System.Type
            public GetInterfaces () : System.Array$1<System.Type>
            public GetInterfaceMap ($interfaceType: System.Type) : System.Reflection.InterfaceMapping
            public IsInstanceOfType ($o: any) : boolean
            public IsEquivalentTo ($other: System.Type) : boolean
            public GetEnumUnderlyingType () : System.Type
            public GetEnumValues () : System.Array
            public MakeArrayType () : System.Type
            public MakeArrayType ($rank: number) : System.Type
            public MakeByRefType () : System.Type
            public MakeGenericType (...typeArguments: System.Type[]) : System.Type
            public MakePointerType () : System.Type
            public static MakeGenericSignatureType ($genericTypeDefinition: System.Type, ...typeArguments: System.Type[]) : System.Type
            public static MakeGenericMethodParameter ($position: number) : System.Type
            public Equals ($o: any) : boolean
            public Equals ($o: System.Type) : boolean
            public static GetTypeFromHandle ($handle: System.RuntimeTypeHandle) : System.Type
            public static GetType ($typeName: string, $throwOnError: boolean, $ignoreCase: boolean) : System.Type
            public static GetType ($typeName: string, $throwOnError: boolean) : System.Type
            public static GetType ($typeName: string) : System.Type
            public static GetType ($typeName: string, $assemblyResolver: System.Func$2<System.Reflection.AssemblyName, System.Reflection.Assembly>, $typeResolver: System.Func$4<System.Reflection.Assembly, string, boolean, System.Type>) : System.Type
            public static GetType ($typeName: string, $assemblyResolver: System.Func$2<System.Reflection.AssemblyName, System.Reflection.Assembly>, $typeResolver: System.Func$4<System.Reflection.Assembly, string, boolean, System.Type>, $throwOnError: boolean) : System.Type
            public static GetType ($typeName: string, $assemblyResolver: System.Func$2<System.Reflection.AssemblyName, System.Reflection.Assembly>, $typeResolver: System.Func$4<System.Reflection.Assembly, string, boolean, System.Type>, $throwOnError: boolean, $ignoreCase: boolean) : System.Type
            public static op_Equality ($left: System.Type, $right: System.Type) : boolean
            public static op_Inequality ($left: System.Type, $right: System.Type) : boolean
            public static ReflectionOnlyGetType ($typeName: string, $throwIfNotFound: boolean, $ignoreCase: boolean) : System.Type
            public static GetTypeFromCLSID ($clsid: System.Guid, $server: string, $throwOnError: boolean) : System.Type
            public static GetTypeFromProgID ($progID: string, $server: string, $throwOnError: boolean) : System.Type
            public Equals ($obj: any) : boolean
            public static Equals ($objA: any, $objB: any) : boolean
        }
        class UInt64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>
        {
            protected [__keep_incompatibility]: never;
        }
        class Attribute extends System.Object implements System.Runtime.InteropServices._Attribute
        {
            protected [__keep_incompatibility]: never;
        }
        class RuntimeTypeHandle extends System.ValueType implements System.Runtime.Serialization.ISerializable
        {
            protected [__keep_incompatibility]: never;
        }
        enum TypeCode
        { Empty = 0, Object = 1, DBNull = 2, Boolean = 3, Char = 4, SByte = 5, Byte = 6, Int16 = 7, UInt16 = 8, Int32 = 9, UInt32 = 10, Int64 = 11, UInt64 = 12, Single = 13, Double = 14, Decimal = 15, DateTime = 16, String = 18 }
        class Guid extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<System.Guid>, System.IEquatable$1<System.Guid>
        {
            protected [__keep_incompatibility]: never;
        }
        interface Func$2<T, TResult>
        { 
        (arg: T) : TResult; 
        Invoke?: (arg: T) => TResult;
        }
        interface Func$4<T1, T2, T3, TResult>
        { 
        (arg1: T1, arg2: T2, arg3: T3) : TResult; 
        Invoke?: (arg1: T1, arg2: T2, arg3: T3) => TResult;
        }
        class UInt32 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        class MarshalByRefObject extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        interface IAsyncDisposable
        {
        }
        class DateTime extends System.ValueType implements System.IFormattable, System.Runtime.Serialization.ISerializable, System.ISpanFormattable, System.IComparable, System.IComparable$1<System.DateTime>, System.IConvertible, System.IEquatable$1<System.DateTime>
        {
            protected [__keep_incompatibility]: never;
        }
        class Byte extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<number>, System.IConvertible, System.IEquatable$1<number>
        {
            protected [__keep_incompatibility]: never;
        }
        interface IAsyncResult
        {
        }
        class Uri extends System.Object implements System.Runtime.Serialization.ISerializable
        {
            protected [__keep_incompatibility]: never;
        }
        class Int64 extends System.ValueType implements System.IFormattable, System.ISpanFormattable, System.IComparable, System.IComparable$1<bigint>, System.IConvertible, System.IEquatable$1<bigint>
        {
            protected [__keep_incompatibility]: never;
        }
        interface AsyncCallback
        { 
        (ar: System.IAsyncResult) : void; 
        Invoke?: (ar: System.IAsyncResult) => void;
        }
        var AsyncCallback: { new (func: (ar: System.IAsyncResult) => void): AsyncCallback; }
        class IntPtr extends System.ValueType implements System.Runtime.Serialization.ISerializable, System.IEquatable$1<System.IntPtr>
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine {
        /** Provides access to application runtime data.
        */
        class Application extends System.Object
        {
            protected [__keep_incompatibility]: never;
            /** Returns true when called in any kind of built Player, or when called in the Editor in Play mode (Read Only).
            */
            public static get isPlaying(): boolean;
            /** Whether the Player currently has focus (Read Only).
            */
            public static get isFocused(): boolean;
            /** Returns a GUID for this build (Read Only).
            */
            public static get buildGUID(): string;
            /** Determines whether the Player should run when the application is in the background
            */
            public static get runInBackground(): boolean;
            public static set runInBackground(value: boolean);
            /** Returns true when Unity is launched with the -batchmode flag from the command line (Read Only).
            */
            public static get isBatchMode(): boolean;
            /** Contains the path to the game data folder on the target device (Read Only).
            */
            public static get dataPath(): string;
            /** The path to the StreamingAssets  folder (Read Only).
            */
            public static get streamingAssetsPath(): string;
            /** Contains the path to a persistent data directory (Read-only).
            */
            public static get persistentDataPath(): string;
            /** Contains the path to a temporary data / cache directory (Read Only).
            */
            public static get temporaryCachePath(): string;
            /** The URL of the document. For WebGL, this is a web URL. For Android, iOS, or Universal Windows Platform (UWP) this is a deep link URL (Read Only).
            */
            public static get absoluteURL(): string;
            /** The version of the Unity runtime used to play the content.
            */
            public static get unityVersion(): string;
            /** Returns application version number (Read Only).
            */
            public static get version(): string;
            /** Returns the name of the store or package that installed the application (Read Only).
            */
            public static get installerName(): string;
            /** Returns the application identifier at runtime. 
            */
            public static get identifier(): string;
            /** Returns application install mode (Read Only).
            */
            public static get installMode(): UnityEngine.ApplicationInstallMode;
            /** Returns application running in a sandbox environment (Read-only).
            */
            public static get sandboxType(): UnityEngine.ApplicationSandboxType;
            /** Returns application product name (Read Only).
            */
            public static get productName(): string;
            /** Returns application company name (Read Only).
            */
            public static get companyName(): string;
            /** A unique cloud project identifier. It is unique for every project (Read Only).
            */
            public static get cloudProjectId(): string;
            /** Specifies the target frame rate at which Unity tries to render your game.
            */
            public static get targetFrameRate(): number;
            public static set targetFrameRate(value: number);
            /** Returns the path to the console log file, or an empty string if the current platform does not support log files.
            */
            public static get consoleLogPath(): string;
            /** Priority of background loading thread.
            */
            public static get backgroundLoadingPriority(): UnityEngine.ThreadPriority;
            public static set backgroundLoadingPriority(value: UnityEngine.ThreadPriority);
            /** Returns false if application is altered in any way after it was built.
            */
            public static get genuine(): boolean;
            /** Returns true if application integrity can be confirmed.
            */
            public static get genuineCheckAvailable(): boolean;
            /** Returns the platform the game is running on (Read Only).
            */
            public static get platform(): UnityEngine.RuntimePlatform;
            /** Identifies whether the current Runtime platform is a known mobile platform.
            */
            public static get isMobilePlatform(): boolean;
            /** Is the current Runtime platform a known console platform.
            */
            public static get isConsolePlatform(): boolean;
            /** The language in which the user's operating system is running in.
            */
            public static get systemLanguage(): UnityEngine.SystemLanguage;
            /** Returns the type of internet reachability currently possible on the device.
            */
            public static get internetReachability(): UnityEngine.NetworkReachability;
            /** Cancellation token raised on exiting Play mode (Editor) or on quitting the application (Read Only).
            */
            public static get exitCancellationToken(): System.Threading.CancellationToken;
            /** Whether the game is running inside the Unity Editor (Read Only).
            */
            public static get isEditor(): boolean;
            public static Quit ($exitCode: number) : void
            /** Quits the player application.
            * @param $exitCode An optional exit code to return when the player application terminates on Windows, Mac and Linux. Defaults to 0.
            */
            public static Quit () : void
            /** Unloads the Unity Player.
            */
            public static Unload () : void
            /** Checks if the streamed level can be loaded.
            */
            public static CanStreamedLevelBeLoaded ($levelIndex: number) : boolean
            /** Checks if the streamed level can be loaded.
            */
            public static CanStreamedLevelBeLoaded ($levelName: string) : boolean
            /** Returns true if the given object is part of the playing world either in any kind of built Player or in Play Mode.
            * @param $obj The object to test.
            * @returns True if the object is part of the playing world. 
            */
            public static IsPlaying ($obj: UnityEngine.Object) : boolean
            /** Is Unity activated with the Pro license?
            */
            public static HasProLicense () : boolean
            public static RequestAdvertisingIdentifierAsync ($delegateMethod: UnityEngine.Application.AdvertisingIdentifierCallback) : boolean
            /** Opens the URL specified, subject to the permissions and limitations of your app’s current platform and environment. 
            * @param $url The URL to open.
            */
            public static OpenURL ($url: string) : void
            /** Get stack trace logging options. The default value is StackTraceLogType.ScriptOnly.
            */
            public static GetStackTraceLogType ($logType: UnityEngine.LogType) : UnityEngine.StackTraceLogType
            /** Set stack trace logging options. The default value is StackTraceLogType.ScriptOnly.
            */
            public static SetStackTraceLogType ($logType: UnityEngine.LogType, $stackTraceType: UnityEngine.StackTraceLogType) : void
            /** Request authorization to use the webcam or microphone on iOS, and the webcam only on WebGL.
            */
            public static RequestUserAuthorization ($mode: UnityEngine.UserAuthorization) : UnityEngine.AsyncOperation
            /** Check if the user has authorized use of the webcam or microphone on iOS and WebGL.
            */
            public static HasUserAuthorization ($mode: UnityEngine.UserAuthorization) : boolean
            public static add_lowMemory ($value: UnityEngine.Application.LowMemoryCallback) : void
            public static remove_lowMemory ($value: UnityEngine.Application.LowMemoryCallback) : void
            public static add_memoryUsageChanged ($value: UnityEngine.Application.MemoryUsageChangedCallback) : void
            public static remove_memoryUsageChanged ($value: UnityEngine.Application.MemoryUsageChangedCallback) : void
            public static add_logMessageReceived ($value: UnityEngine.Application.LogCallback) : void
            public static remove_logMessageReceived ($value: UnityEngine.Application.LogCallback) : void
            public static add_logMessageReceivedThreaded ($value: UnityEngine.Application.LogCallback) : void
            public static remove_logMessageReceivedThreaded ($value: UnityEngine.Application.LogCallback) : void
            public static add_onBeforeRender ($value: UnityEngine.Events.UnityAction) : void
            public static remove_onBeforeRender ($value: UnityEngine.Events.UnityAction) : void
            public static add_focusChanged ($value: System.Action$1<boolean>) : void
            public static remove_focusChanged ($value: System.Action$1<boolean>) : void
            public static add_deepLinkActivated ($value: System.Action$1<string>) : void
            public static remove_deepLinkActivated ($value: System.Action$1<string>) : void
            public static add_wantsToQuit ($value: System.Func$1<boolean>) : void
            public static remove_wantsToQuit ($value: System.Func$1<boolean>) : void
            public static add_quitting ($value: System.Action) : void
            public static remove_quitting ($value: System.Action) : void
            public static add_unloading ($value: System.Action) : void
            public static remove_unloading ($value: System.Action) : void
            public constructor ()
        }
        /** Base class for all objects Unity can reference.
        */
        class Object extends System.Object
        {
            protected [__keep_incompatibility]: never;
            /** The name of the object.
            */
            public get name(): string;
            public set name(value: string);
            /** Should the object be hidden, saved with the Scene or modifiable by the user?
            */
            public get hideFlags(): UnityEngine.HideFlags;
            public set hideFlags(value: UnityEngine.HideFlags);
            /** Gets  the instance ID of the object.
            * @returns Returns the instance ID of the object. 
            */
            public GetInstanceID () : number
            public static op_Implicit ($exists: UnityEngine.Object) : boolean
            public static InstantiateAsync ($original: UnityEngine.Object) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $parent: UnityEngine.Transform) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $parent: UnityEngine.Transform, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $count: number) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $count: number, $parent: UnityEngine.Transform) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $count: number, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $count: number, $parent: UnityEngine.Transform, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            public static InstantiateAsync ($original: UnityEngine.Object, $count: number, $parent: UnityEngine.Transform, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion, $cancellationToken: System.Threading.CancellationToken) : UnityEngine.AsyncInstantiateOperation$1<UnityEngine.Object>
            /** Clones the object original and returns the clone.
            * @param $original An existing object that you want to make a copy of.
            * @param $position Position for the new object.
            * @param $rotation Orientation of the new object.
            * @param $parent Parent that will be assigned to the new object.
            * @param $instantiateInWorldSpace When you assign a parent Object, pass true to position the new object directly in world space. Pass false to set the Object’s position relative to its new parent.
            * @returns The instantiated clone. 
            */
            public static Instantiate ($original: UnityEngine.Object, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion) : UnityEngine.Object
            /** Clones the object original and returns the clone.
            * @param $original An existing object that you want to make a copy of.
            * @param $position Position for the new object.
            * @param $rotation Orientation of the new object.
            * @param $parent Parent that will be assigned to the new object.
            * @param $instantiateInWorldSpace When you assign a parent Object, pass true to position the new object directly in world space. Pass false to set the Object’s position relative to its new parent.
            * @returns The instantiated clone. 
            */
            public static Instantiate ($original: UnityEngine.Object, $position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion, $parent: UnityEngine.Transform) : UnityEngine.Object
            /** Clones the object original and returns the clone.
            * @param $original An existing object that you want to make a copy of.
            * @param $position Position for the new object.
            * @param $rotation Orientation of the new object.
            * @param $parent Parent that will be assigned to the new object.
            * @param $instantiateInWorldSpace When you assign a parent Object, pass true to position the new object directly in world space. Pass false to set the Object’s position relative to its new parent.
            * @returns The instantiated clone. 
            */
            public static Instantiate ($original: UnityEngine.Object) : UnityEngine.Object
            /** Clones the object original and returns the clone.
            * @param $original An existing object that you want to make a copy of.
            * @param $position Position for the new object.
            * @param $rotation Orientation of the new object.
            * @param $parent Parent that will be assigned to the new object.
            * @param $instantiateInWorldSpace When you assign a parent Object, pass true to position the new object directly in world space. Pass false to set the Object’s position relative to its new parent.
            * @returns The instantiated clone. 
            */
            public static Instantiate ($original: UnityEngine.Object, $scene: UnityEngine.SceneManagement.Scene) : UnityEngine.Object
            /** Clones the object original and returns the clone.
            * @param $original An existing object that you want to make a copy of.
            * @param $position Position for the new object.
            * @param $rotation Orientation of the new object.
            * @param $parent Parent that will be assigned to the new object.
            * @param $instantiateInWorldSpace When you assign a parent Object, pass true to position the new object directly in world space. Pass false to set the Object’s position relative to its new parent.
            * @returns The instantiated clone. 
            */
            public static Instantiate ($original: UnityEngine.Object, $parent: UnityEngine.Transform) : UnityEngine.Object
            /** Clones the object original and returns the clone.
            * @param $original An existing object that you want to make a copy of.
            * @param $position Position for the new object.
            * @param $rotation Orientation of the new object.
            * @param $parent Parent that will be assigned to the new object.
            * @param $instantiateInWorldSpace When you assign a parent Object, pass true to position the new object directly in world space. Pass false to set the Object’s position relative to its new parent.
            * @returns The instantiated clone. 
            */
            public static Instantiate ($original: UnityEngine.Object, $parent: UnityEngine.Transform, $instantiateInWorldSpace: boolean) : UnityEngine.Object
            public static Instantiate ($original: UnityEngine.Object, $parent: UnityEngine.Transform, $worldPositionStays: boolean) : UnityEngine.Object
            /** Removes a GameObject, component or asset.
            * @param $obj The object to destroy.
            * @param $t The optional amount of time to delay before destroying the object.
            */
            public static Destroy ($obj: UnityEngine.Object, $t: number) : void
            /** Removes a GameObject, component or asset.
            * @param $obj The object to destroy.
            * @param $t The optional amount of time to delay before destroying the object.
            */
            public static Destroy ($obj: UnityEngine.Object) : void
            /** Destroys the object obj immediately. You are strongly recommended to use Destroy instead.
            * @param $obj Object to be destroyed.
            * @param $allowDestroyingAssets Set to true to allow assets to be destroyed.
            */
            public static DestroyImmediate ($obj: UnityEngine.Object, $allowDestroyingAssets: boolean) : void
            /** Destroys the object obj immediately. You are strongly recommended to use Destroy instead.
            * @param $obj Object to be destroyed.
            * @param $allowDestroyingAssets Set to true to allow assets to be destroyed.
            */
            public static DestroyImmediate ($obj: UnityEngine.Object) : void
            /** Retrieves a list of all loaded objects of Type type.
            * @param $type The type of object to find.
            * @param $findObjectsInactive Whether to include components attached to inactive GameObjects. If you don't specify this parameter, this function doesn't include inactive objects in the results.
            * @param $sortMode Whether and how to sort the returned array. Not sorting the array makes this function run significantly faster.
            * @returns The array of objects found matching the type specified. 
            */
            public static FindObjectsByType ($type: System.Type, $sortMode: UnityEngine.FindObjectsSortMode) : System.Array$1<UnityEngine.Object>
            /** Retrieves a list of all loaded objects of Type type.
            * @param $type The type of object to find.
            * @param $findObjectsInactive Whether to include components attached to inactive GameObjects. If you don't specify this parameter, this function doesn't include inactive objects in the results.
            * @param $sortMode Whether and how to sort the returned array. Not sorting the array makes this function run significantly faster.
            * @returns The array of objects found matching the type specified. 
            */
            public static FindObjectsByType ($type: System.Type, $findObjectsInactive: UnityEngine.FindObjectsInactive, $sortMode: UnityEngine.FindObjectsSortMode) : System.Array$1<UnityEngine.Object>
            /** Do not destroy the target Object when loading a new Scene.
            * @param $target An Object not destroyed on Scene change.
            */
            public static DontDestroyOnLoad ($target: UnityEngine.Object) : void
            /** Retrieves the first active loaded object of Type type.
            * @param $type The type of object to find.
            * @param $findObjectsInactive Whether to include components attached to inactive GameObjects. If you don't specify this parameter, this function doesn't include inactive objects in the results.
            * @returns Returns the first active loaded object that matches the specified type. If no object matches the specified type, returns null. 
            */
            public static FindFirstObjectByType ($type: System.Type) : UnityEngine.Object
            /** Retrieves any active loaded object of Type type.
            * @param $type The type of object to find.
            * @param $findObjectsInactive Whether to include components attached to inactive GameObjects. If you don't specify this parameter, this function doesn't include inactive objects in the results.
            * @returns Returns an arbitrary active loaded object that matches the specified type. If no object matches the specified type, returns null. 
            */
            public static FindAnyObjectByType ($type: System.Type) : UnityEngine.Object
            /** Retrieves the first active loaded object of Type type.
            * @param $type The type of object to find.
            * @param $findObjectsInactive Whether to include components attached to inactive GameObjects. If you don't specify this parameter, this function doesn't include inactive objects in the results.
            * @returns Returns the first active loaded object that matches the specified type. If no object matches the specified type, returns null. 
            */
            public static FindFirstObjectByType ($type: System.Type, $findObjectsInactive: UnityEngine.FindObjectsInactive) : UnityEngine.Object
            /** Retrieves any active loaded object of Type type.
            * @param $type The type of object to find.
            * @param $findObjectsInactive Whether to include components attached to inactive GameObjects. If you don't specify this parameter, this function doesn't include inactive objects in the results.
            * @returns Returns an arbitrary active loaded object that matches the specified type. If no object matches the specified type, returns null. 
            */
            public static FindAnyObjectByType ($type: System.Type, $findObjectsInactive: UnityEngine.FindObjectsInactive) : UnityEngine.Object
            public static op_Equality ($x: UnityEngine.Object, $y: UnityEngine.Object) : boolean
            public static op_Inequality ($x: UnityEngine.Object, $y: UnityEngine.Object) : boolean
            public constructor ()
        }
        /** Application installation mode (Read Only).
        */
        enum ApplicationInstallMode
        { Unknown = 0, Store = 1, DeveloperBuild = 2, Adhoc = 3, Enterprise = 4, Editor = 5 }
        /** Application sandbox type.
        */
        enum ApplicationSandboxType
        { Unknown = 0, NotSandboxed = 1, Sandboxed = 2, SandboxBroken = 3 }
        /** Stack trace logging options.
        */
        enum StackTraceLogType
        { None = 0, ScriptOnly = 1, Full = 2 }
        /** The type of the log message in Debug.unityLogger.Log or delegate registered with Application.RegisterLogCallback.
        */
        enum LogType
        { Error = 0, Assert = 1, Warning = 2, Log = 3, Exception = 4 }
        /** Priority of a thread.
        */
        enum ThreadPriority
        { Low = 0, BelowNormal = 1, Normal = 2, High = 4 }
        /** Base class for all yield instructions.
        */
        class YieldInstruction extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** Asynchronous operation coroutine.
        */
        class AsyncOperation extends UnityEngine.YieldInstruction
        {
            protected [__keep_incompatibility]: never;
        }
        /** Constants to pass to Application.RequestUserAuthorization.
        */
        enum UserAuthorization
        { WebCam = 1, Microphone = 2 }
        /** The platform application is running. Returned by Application.platform.
        */
        enum RuntimePlatform
        { OSXEditor = 0, OSXPlayer = 1, WindowsPlayer = 2, OSXWebPlayer = 3, OSXDashboardPlayer = 4, WindowsWebPlayer = 5, WindowsEditor = 7, IPhonePlayer = 8, XBOX360 = 10, PS3 = 9, Android = 11, NaCl = 12, FlashPlayer = 15, LinuxPlayer = 13, LinuxEditor = 16, WebGLPlayer = 17, MetroPlayerX86 = 18, WSAPlayerX86 = 18, MetroPlayerX64 = 19, WSAPlayerX64 = 19, MetroPlayerARM = 20, WSAPlayerARM = 20, WP8Player = 21, BB10Player = 22, BlackBerryPlayer = 22, TizenPlayer = 23, PSP2 = 24, PS4 = 25, PSM = 26, XboxOne = 27, SamsungTVPlayer = 28, WiiU = 30, tvOS = 31, Switch = 32, Lumin = 33, Stadia = 34, CloudRendering = -1, LinuxHeadlessSimulation = 35, GameCoreScarlett = -1, GameCoreXboxSeries = 36, GameCoreXboxOne = 37, PS5 = 38, EmbeddedLinuxArm64 = 39, EmbeddedLinuxArm32 = 40, EmbeddedLinuxX64 = 41, EmbeddedLinuxX86 = 42, LinuxServer = 43, WindowsServer = 44, OSXServer = 45, QNXArm32 = 46, QNXArm64 = 47, QNXX64 = 48, QNXX86 = 49, VisionOS = 50, ReservedCFE = 51 }
        /** The language the user's operating system is running in. Returned by Application.systemLanguage.
        */
        enum SystemLanguage
        { Afrikaans = 0, Arabic = 1, Basque = 2, Belarusian = 3, Bulgarian = 4, Catalan = 5, Chinese = 6, Czech = 7, Danish = 8, Dutch = 9, English = 10, Estonian = 11, Faroese = 12, Finnish = 13, French = 14, German = 15, Greek = 16, Hebrew = 17, Hugarian = 18, Icelandic = 19, Indonesian = 20, Italian = 21, Japanese = 22, Korean = 23, Latvian = 24, Lithuanian = 25, Norwegian = 26, Polish = 27, Portuguese = 28, Romanian = 29, Russian = 30, SerboCroatian = 31, Slovak = 32, Slovenian = 33, Spanish = 34, Swedish = 35, Thai = 36, Turkish = 37, Ukrainian = 38, Vietnamese = 39, ChineseSimplified = 40, ChineseTraditional = 41, Hindi = 42, Unknown = 43, Hungarian = 18 }
        /** Describes network reachability options.
        */
        enum NetworkReachability
        { NotReachable = 0, ReachableViaCarrierDataNetwork = 1, ReachableViaLocalAreaNetwork = 2 }
        /** Contains information about a change in the application's memory usage.
        */
        class ApplicationMemoryUsageChange extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        /** Class containing methods to ease debugging while developing a game.
        */
        class Debug extends System.Object
        {
            protected [__keep_incompatibility]: never;
            /** Get default debug logger.
            */
            public static get unityLogger(): UnityEngine.ILogger;
            /** Allows you to enable or disable the developer console.
            */
            public static get developerConsoleEnabled(): boolean;
            public static set developerConsoleEnabled(value: boolean);
            /** Controls whether the development console is visible.
            */
            public static get developerConsoleVisible(): boolean;
            public static set developerConsoleVisible(value: boolean);
            /** In the Build Settings dialog there is a check box called "Development Build".
            */
            public static get isDebugBuild(): boolean;
            /** Draws a line between specified start and end points.
            * @param $start Point in world space where the line should start.
            * @param $end Point in world space where the line should end.
            * @param $color Color of the line.
            * @param $duration How long the line should be visible for.
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawLine ($start: UnityEngine.Vector3, $end: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number) : void
            /** Draws a line between specified start and end points.
            * @param $start Point in world space where the line should start.
            * @param $end Point in world space where the line should end.
            * @param $color Color of the line.
            * @param $duration How long the line should be visible for.
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawLine ($start: UnityEngine.Vector3, $end: UnityEngine.Vector3, $color: UnityEngine.Color) : void
            /** Draws a line between specified start and end points.
            * @param $start Point in world space where the line should start.
            * @param $end Point in world space where the line should end.
            * @param $color Color of the line.
            * @param $duration How long the line should be visible for.
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawLine ($start: UnityEngine.Vector3, $end: UnityEngine.Vector3) : void
            /** Draws a line between specified start and end points.
            * @param $start Point in world space where the line should start.
            * @param $end Point in world space where the line should end.
            * @param $color Color of the line.
            * @param $duration How long the line should be visible for.
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawLine ($start: UnityEngine.Vector3, $end: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number, $depthTest: boolean) : void
            /** Draws a line from start to start + dir in world coordinates.
            * @param $start Point in world space where the ray should start.
            * @param $dir Direction and length of the ray.
            * @param $color Color of the drawn line.
            * @param $duration How long the line will be visible for (in seconds).
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawRay ($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number) : void
            /** Draws a line from start to start + dir in world coordinates.
            * @param $start Point in world space where the ray should start.
            * @param $dir Direction and length of the ray.
            * @param $color Color of the drawn line.
            * @param $duration How long the line will be visible for (in seconds).
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawRay ($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3, $color: UnityEngine.Color) : void
            /** Draws a line from start to start + dir in world coordinates.
            * @param $start Point in world space where the ray should start.
            * @param $dir Direction and length of the ray.
            * @param $color Color of the drawn line.
            * @param $duration How long the line will be visible for (in seconds).
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawRay ($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3) : void
            /** Draws a line from start to start + dir in world coordinates.
            * @param $start Point in world space where the ray should start.
            * @param $dir Direction and length of the ray.
            * @param $color Color of the drawn line.
            * @param $duration How long the line will be visible for (in seconds).
            * @param $depthTest Determines whether objects closer to the camera obscure the line.
            */
            public static DrawRay ($start: UnityEngine.Vector3, $dir: UnityEngine.Vector3, $color: UnityEngine.Color, $duration: number, $depthTest: boolean) : void
            /** Pauses the editor.
            */
            public static Break () : void
            public static DebugBreak () : void
            /** Logs a message to the Unity Console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static Log ($message: any) : void
            /** Logs a message to the Unity Console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static Log ($message: any, $context: UnityEngine.Object) : void
            /** Logs a formatted message to the Unity Console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            * @param $logType Type of message e.g. warn or error etc.
            * @param $logOptions Option flags to treat the log message special.
            */
            public static LogFormat ($format: string, ...args: any[]) : void
            /** Logs a formatted message to the Unity Console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            * @param $logType Type of message e.g. warn or error etc.
            * @param $logOptions Option flags to treat the log message special.
            */
            public static LogFormat ($context: UnityEngine.Object, $format: string, ...args: any[]) : void
            /** Logs a formatted message to the Unity Console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            * @param $logType Type of message e.g. warn or error etc.
            * @param $logOptions Option flags to treat the log message special.
            */
            public static LogFormat ($logType: UnityEngine.LogType, $logOptions: UnityEngine.LogOption, $context: UnityEngine.Object, $format: string, ...args: any[]) : void
            /** A variant of Debug.Log that logs an error message to the console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static LogError ($message: any) : void
            /** A variant of Debug.Log that logs an error message to the console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static LogError ($message: any, $context: UnityEngine.Object) : void
            /** Logs a formatted error message to the Unity console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static LogErrorFormat ($format: string, ...args: any[]) : void
            /** Logs a formatted error message to the Unity console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static LogErrorFormat ($context: UnityEngine.Object, $format: string, ...args: any[]) : void
            /** Clears errors from the developer console.
            */
            public static ClearDeveloperConsole () : void
            /** A variant of Debug.Log that logs an error message to the console.
            * @param $context Object to which the message applies.
            * @param $exception Runtime Exception.
            */
            public static LogException ($exception: System.Exception) : void
            /** A variant of Debug.Log that logs an error message to the console.
            * @param $context Object to which the message applies.
            * @param $exception Runtime Exception.
            */
            public static LogException ($exception: System.Exception, $context: UnityEngine.Object) : void
            /** A variant of Debug.Log that logs a warning message to the console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static LogWarning ($message: any) : void
            /** A variant of Debug.Log that logs a warning message to the console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static LogWarning ($message: any, $context: UnityEngine.Object) : void
            /** Logs a formatted warning message to the Unity Console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static LogWarningFormat ($format: string, ...args: any[]) : void
            /** Logs a formatted warning message to the Unity Console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static LogWarningFormat ($context: UnityEngine.Object, $format: string, ...args: any[]) : void
            /** Assert a condition and logs an error message to the Unity console on failure.
            * @param $condition Condition you expect to be true.
            * @param $context Object to which the message applies.
            * @param $message String or object to be converted to string representation for display.
            */
            public static Assert ($condition: boolean) : void
            /** Assert a condition and logs an error message to the Unity console on failure.
            * @param $condition Condition you expect to be true.
            * @param $context Object to which the message applies.
            * @param $message String or object to be converted to string representation for display.
            */
            public static Assert ($condition: boolean, $context: UnityEngine.Object) : void
            /** Assert a condition and logs an error message to the Unity console on failure.
            * @param $condition Condition you expect to be true.
            * @param $context Object to which the message applies.
            * @param $message String or object to be converted to string representation for display.
            */
            public static Assert ($condition: boolean, $message: any) : void
            public static Assert ($condition: boolean, $message: string) : void
            /** Assert a condition and logs an error message to the Unity console on failure.
            * @param $condition Condition you expect to be true.
            * @param $context Object to which the message applies.
            * @param $message String or object to be converted to string representation for display.
            */
            public static Assert ($condition: boolean, $message: any, $context: UnityEngine.Object) : void
            public static Assert ($condition: boolean, $message: string, $context: UnityEngine.Object) : void
            /** Assert a condition and logs a formatted error message to the Unity console on failure.
            * @param $condition Condition you expect to be true.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static AssertFormat ($condition: boolean, $format: string, ...args: any[]) : void
            /** Assert a condition and logs a formatted error message to the Unity console on failure.
            * @param $condition Condition you expect to be true.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static AssertFormat ($condition: boolean, $context: UnityEngine.Object, $format: string, ...args: any[]) : void
            /** A variant of Debug.Log that logs an assertion message to the console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static LogAssertion ($message: any) : void
            /** A variant of Debug.Log that logs an assertion message to the console.
            * @param $message String or object to be converted to string representation for display.
            * @param $context Object to which the message applies.
            */
            public static LogAssertion ($message: any, $context: UnityEngine.Object) : void
            /** Logs a formatted assertion message to the Unity console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static LogAssertionFormat ($format: string, ...args: any[]) : void
            /** Logs a formatted assertion message to the Unity console.
            * @param $format A composite format string.
            * @param $args Format arguments.
            * @param $context Object to which the message applies.
            */
            public static LogAssertionFormat ($context: UnityEngine.Object, $format: string, ...args: any[]) : void
            /** Returns any captured startup logs
            */
            public static RetrieveStartupLogs () : System.Array$1<UnityEngine.Debug.StartupLog>
            /** Performs an integrity check of the currently running process and return discovered errors.
            * @param $level Thoroughness of integrity check.
            */
            public static CheckIntegrity ($level: UnityEngine.IntegrityCheckLevel) : string
            /** Returns whether a given validation level is currently enabled.
            * @param $level The validation level to test.
            */
            public static IsValidationLevelEnabled ($level: UnityEngine.ValidationLevel) : boolean
            public constructor ()
        }
        interface ILogger extends UnityEngine.ILogHandler
        {
        }
        interface ILogHandler
        {
        }
        /** Representation of 3D vectors and points.
        */
        class Vector3 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector3>
        {
            protected [__keep_incompatibility]: never;
            public static kEpsilon : number
            public static kEpsilonNormalSqrt : number
            /** X component of the vector.
            */
            public x : number
            /** Y component of the vector.
            */
            public y : number
            /** Z component of the vector.
            */
            public z : number
            /** Returns a normalized vector based on the current vector. The normalized vector has a magnitude of 1 and is in the same direction as the current vector. Returns a zero vector If the current vector is too small to be normalized.
            */
            public get normalized(): UnityEngine.Vector3;
            /** Returns the length of this vector (Read Only).
            */
            public get magnitude(): number;
            /** Returns the squared length of this vector (Read Only).
            */
            public get sqrMagnitude(): number;
            /** Shorthand for writing Vector3(0, 0, 0).
            */
            public static get zero(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(1, 1, 1).
            */
            public static get one(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(0, 0, 1).
            */
            public static get forward(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(0, 0, -1).
            */
            public static get back(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(0, 1, 0).
            */
            public static get up(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(0, -1, 0).
            */
            public static get down(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(-1, 0, 0).
            */
            public static get left(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(1, 0, 0).
            */
            public static get right(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).
            */
            public static get positiveInfinity(): UnityEngine.Vector3;
            /** Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).
            */
            public static get negativeInfinity(): UnityEngine.Vector3;
            /** Spherically interpolates between two vectors.
            */
            public static Slerp ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3, $t: number) : UnityEngine.Vector3
            /** Spherically interpolates between two vectors.
            */
            public static SlerpUnclamped ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3, $t: number) : UnityEngine.Vector3
            /** Makes vectors normalized and orthogonal to each other.
            */
            public static OrthoNormalize ($normal: $Ref<UnityEngine.Vector3>, $tangent: $Ref<UnityEngine.Vector3>) : void
            /** Makes vectors normalized and orthogonal to each other.
            */
            public static OrthoNormalize ($normal: $Ref<UnityEngine.Vector3>, $tangent: $Ref<UnityEngine.Vector3>, $binormal: $Ref<UnityEngine.Vector3>) : void
            /** Rotates a vector current towards target.
            * @param $current The vector being managed.
            * @param $target The vector.
            * @param $maxRadiansDelta The maximum angle in radians allowed for this rotation.
            * @param $maxMagnitudeDelta The maximum allowed change in vector magnitude for this rotation.
            * @returns The location that RotateTowards generates. 
            */
            public static RotateTowards ($current: UnityEngine.Vector3, $target: UnityEngine.Vector3, $maxRadiansDelta: number, $maxMagnitudeDelta: number) : UnityEngine.Vector3
            /** Linearly interpolates between two points.
            * @param $a Start value, returned when t = 0.
            * @param $b End value, returned when t = 1.
            * @param $t Value used to interpolate between a and b.
            * @returns Interpolated value, equals to a + (b - a) * t. 
            */
            public static Lerp ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3, $t: number) : UnityEngine.Vector3
            /** Linearly interpolates between two vectors.
            */
            public static LerpUnclamped ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3, $t: number) : UnityEngine.Vector3
            /** Calculate a position between the points specified by current and target, moving no farther than the distance specified by maxDistanceDelta.
            * @param $current The position to move from.
            * @param $target The position to move towards.
            * @param $maxDistanceDelta Distance to move current per call.
            * @returns The new position. 
            */
            public static MoveTowards ($current: UnityEngine.Vector3, $target: UnityEngine.Vector3, $maxDistanceDelta: number) : UnityEngine.Vector3
            /** Gradually changes a vector towards a desired goal over time.
            * @param $current The current position.
            * @param $target The position we are trying to reach.
            * @param $currentVelocity The current velocity, this value is modified by the function every time you call it.
            * @param $smoothTime Approximately the time it will take to reach the target. A smaller value will reach the target faster.
            * @param $maxSpeed Optionally allows you to clamp the maximum speed.
            * @param $deltaTime The time since the last call to this function. By default Time.deltaTime.
            */
            public static SmoothDamp ($current: UnityEngine.Vector3, $target: UnityEngine.Vector3, $currentVelocity: $Ref<UnityEngine.Vector3>, $smoothTime: number, $maxSpeed: number) : UnityEngine.Vector3
            /** Gradually changes a vector towards a desired goal over time.
            * @param $current The current position.
            * @param $target The position we are trying to reach.
            * @param $currentVelocity The current velocity, this value is modified by the function every time you call it.
            * @param $smoothTime Approximately the time it will take to reach the target. A smaller value will reach the target faster.
            * @param $maxSpeed Optionally allows you to clamp the maximum speed.
            * @param $deltaTime The time since the last call to this function. By default Time.deltaTime.
            */
            public static SmoothDamp ($current: UnityEngine.Vector3, $target: UnityEngine.Vector3, $currentVelocity: $Ref<UnityEngine.Vector3>, $smoothTime: number) : UnityEngine.Vector3
            /** Gradually changes a vector towards a desired goal over time.
            * @param $current The current position.
            * @param $target The position we are trying to reach.
            * @param $currentVelocity The current velocity, this value is modified by the function every time you call it.
            * @param $smoothTime Approximately the time it will take to reach the target. A smaller value will reach the target faster.
            * @param $maxSpeed Optionally allows you to clamp the maximum speed.
            * @param $deltaTime The time since the last call to this function. By default Time.deltaTime.
            */
            public static SmoothDamp ($current: UnityEngine.Vector3, $target: UnityEngine.Vector3, $currentVelocity: $Ref<UnityEngine.Vector3>, $smoothTime: number, $maxSpeed: number, $deltaTime: number) : UnityEngine.Vector3
            public get_Item ($index: number) : number
            public set_Item ($index: number, $value: number) : void
            /** Set x, y and z components of an existing Vector3.
            */
            public Set ($newX: number, $newY: number, $newZ: number) : void
            /** Multiplies two vectors component-wise.
            */
            public static Scale ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Multiplies every component of this vector by the same component of scale.
            */
            public Scale ($scale: UnityEngine.Vector3) : void
            /** Cross Product of two vectors.
            */
            public static Cross ($lhs: UnityEngine.Vector3, $rhs: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Returns true if the given vector is exactly equal to this vector.
            */
            public Equals ($other: any) : boolean
            public Equals ($other: UnityEngine.Vector3) : boolean
            /** Reflects a vector off the plane defined by a normal.
            * @param $inDirection The direction vector towards the plane.
            * @param $inNormal The normal vector that defines the plane.
            */
            public static Reflect ($inDirection: UnityEngine.Vector3, $inNormal: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Returns a normalized vector based on the given vector. The normalized vector has a magnitude of 1 and is in the same direction as the given vector. Returns a zero vector If the given vector is too small to be normalized.
            * @param $value The vector to be normalized.
            * @returns A new vector with the same direction as the original vector but with a magnitude of 1.0. 
            */
            public static Normalize ($value: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Makes this vector have a magnitude of 1.
            */
            public Normalize () : void
            /** Dot Product of two vectors.
            */
            public static Dot ($lhs: UnityEngine.Vector3, $rhs: UnityEngine.Vector3) : number
            /** Projects a vector onto another vector.
            */
            public static Project ($vector: UnityEngine.Vector3, $onNormal: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Projects a vector onto a plane.
            * @param $vector The vector to project on the plane.
            * @param $planeNormal The normal which defines the plane to project on.
            * @returns The orthogonal projection of vector on the plane. 
            */
            public static ProjectOnPlane ($vector: UnityEngine.Vector3, $planeNormal: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Calculates the angle between two vectors.
            * @param $from The vector from which the angular difference is measured.
            * @param $to The vector to which the angular difference is measured.
            * @returns The angle in degrees between the two vectors. 
            */
            public static Angle ($from: UnityEngine.Vector3, $to: UnityEngine.Vector3) : number
            /** Calculates the signed angle between vectors from and to in relation to axis.
            * @param $from The vector from which the angular difference is measured.
            * @param $to The vector to which the angular difference is measured.
            * @param $axis A vector around which the other vectors are rotated.
            * @returns Returns the signed angle between from and to in degrees. 
            */
            public static SignedAngle ($from: UnityEngine.Vector3, $to: UnityEngine.Vector3, $axis: UnityEngine.Vector3) : number
            /** Returns the distance between a and b.
            */
            public static Distance ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3) : number
            /** Returns a copy of vector with its magnitude clamped to maxLength.
            */
            public static ClampMagnitude ($vector: UnityEngine.Vector3, $maxLength: number) : UnityEngine.Vector3
            public static Magnitude ($vector: UnityEngine.Vector3) : number
            public static SqrMagnitude ($vector: UnityEngine.Vector3) : number
            /** Returns a vector that is made from the smallest components of two vectors.
            */
            public static Min ($lhs: UnityEngine.Vector3, $rhs: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Returns a vector that is made from the largest components of two vectors.
            */
            public static Max ($lhs: UnityEngine.Vector3, $rhs: UnityEngine.Vector3) : UnityEngine.Vector3
            public static op_Addition ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3) : UnityEngine.Vector3
            public static op_Subtraction ($a: UnityEngine.Vector3, $b: UnityEngine.Vector3) : UnityEngine.Vector3
            public static op_UnaryNegation ($a: UnityEngine.Vector3) : UnityEngine.Vector3
            public static op_Multiply ($a: UnityEngine.Vector3, $d: number) : UnityEngine.Vector3
            public static op_Multiply ($d: number, $a: UnityEngine.Vector3) : UnityEngine.Vector3
            public static op_Division ($a: UnityEngine.Vector3, $d: number) : UnityEngine.Vector3
            public static op_Equality ($lhs: UnityEngine.Vector3, $rhs: UnityEngine.Vector3) : boolean
            public static op_Inequality ($lhs: UnityEngine.Vector3, $rhs: UnityEngine.Vector3) : boolean
            /** Returns a formatted string for this vector.
            * @param $format A numeric format string.
            * @param $formatProvider An object that specifies culture-specific formatting.
            */
            public ToString () : string
            /** Returns a formatted string for this vector.
            * @param $format A numeric format string.
            * @param $formatProvider An object that specifies culture-specific formatting.
            */
            public ToString ($format: string) : string
            /** Returns a formatted string for this vector.
            * @param $format A numeric format string.
            * @param $formatProvider An object that specifies culture-specific formatting.
            */
            public ToString ($format: string, $formatProvider: System.IFormatProvider) : string
            public constructor ($x: number, $y: number, $z: number)
            public constructor ($x: number, $y: number)
            public Equals ($obj: any) : boolean
            public static Equals ($objA: any, $objB: any) : boolean
            public constructor ()
        }
        /** Representation of RGBA colors.
        */
        class Color extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Color>
        {
            protected [__keep_incompatibility]: never;
        }
        /** Option flags for specifying special treatment of a log message.
        */
        enum LogOption
        { None = 0, NoStacktrace = 1 }
        /** 
        Enumeration specifying a integrity check level.
        Additional resources: Debug.CheckIntegrity
        */
        enum IntegrityCheckLevel
        { Low = 1, Medium = 2, High = 3 }
        /** 
        Enumeration specifying a validation level.
        Additional resources: Debug.IsValidationLevelEnabled
        */
        enum ValidationLevel
        { None = 0, Low = 1, Medium = 2, High = 3 }
        /** Provides an interface to get time information from Unity.
        */
        class Time extends System.Object
        {
            protected [__keep_incompatibility]: never;
            /** The time at the beginning of the current frame in seconds since the start of the application (Read Only).
            */
            public static get time(): number;
            /** The double precision time at the beginning of this frame (Read Only). This is the time in seconds since the start of the game.
            */
            public static get timeAsDouble(): number;
            /** The time this frame has started (Read Only). This is the time in seconds since the start of the game represented as a RationalTime.
            */
            public static get timeAsRational(): Unity.IntegerTime.RationalTime;
            /** The time in seconds since the last non-additive scene finished loading (Read Only).
            */
            public static get timeSinceLevelLoad(): number;
            /** The double precision time in seconds since the last non-additive scene finished loading (Read Only).
            */
            public static get timeSinceLevelLoadAsDouble(): number;
            /** The interval in seconds from the last frame to the current one (Read Only).
            */
            public static get deltaTime(): number;
            /** The time at which the current MonoBehaviour.FixedUpdate started in seconds since the start of the game (Read Only).
            */
            public static get fixedTime(): number;
            /** The double precision time since the last MonoBehaviour.FixedUpdate started (Read Only). This is the time in seconds since the start of the game.
            */
            public static get fixedTimeAsDouble(): number;
            /** The timeScale-independent time for this frame (Read Only). This is the time in seconds since the start of the game.
            */
            public static get unscaledTime(): number;
            /** The double precision timeScale-independent time for this frame (Read Only). This is the time in seconds since the start of the game.
            */
            public static get unscaledTimeAsDouble(): number;
            /** The timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate phase (Read Only). This is the time in seconds since the start of the game.
            */
            public static get fixedUnscaledTime(): number;
            /** The double precision timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate (Read Only). This is the time in seconds since the start of the game.
            */
            public static get fixedUnscaledTimeAsDouble(): number;
            /** The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
            */
            public static get unscaledDeltaTime(): number;
            /** The interval in seconds of timeScale-independent ("real") time at which physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.(Read Only).
            */
            public static get fixedUnscaledDeltaTime(): number;
            /** The interval in seconds of in-game time at which physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.
            */
            public static get fixedDeltaTime(): number;
            public static set fixedDeltaTime(value: number);
            /** The maximum value of Time.deltaTime in any given frame. This is a time in seconds that limits the increase of Time.time between two frames.
            */
            public static get maximumDeltaTime(): number;
            public static set maximumDeltaTime(value: number);
            /** A smoothed out Time.deltaTime (Read Only).
            */
            public static get smoothDeltaTime(): number;
            /** The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates.
            */
            public static get maximumParticleDeltaTime(): number;
            public static set maximumParticleDeltaTime(value: number);
            /** The scale at which time passes.
            */
            public static get timeScale(): number;
            public static set timeScale(value: number);
            /** The total number of frames since the start of the game (Read Only).
            */
            public static get frameCount(): number;
            public static get renderedFrameCount(): number;
            /** The real time in seconds since the game started (Read Only).
            */
            public static get realtimeSinceStartup(): number;
            /** The real time in seconds since the game started (Read Only). Double precision version of Time.realtimeSinceStartup. 
            */
            public static get realtimeSinceStartupAsDouble(): number;
            /** Slows your application’s playback time to allow Unity to save screenshots in between frames.
            */
            public static get captureDeltaTime(): number;
            public static set captureDeltaTime(value: number);
            /** Slows your application’s playback time to allow Unity to save screenshots in between frames.
            */
            public static get captureDeltaTimeRational(): Unity.IntegerTime.RationalTime;
            public static set captureDeltaTimeRational(value: Unity.IntegerTime.RationalTime);
            /** The reciprocal of Time.captureDeltaTime.
            */
            public static get captureFramerate(): number;
            public static set captureFramerate(value: number);
            /** Returns true if called inside a fixed time step callback (like MonoBehaviour's MonoBehaviour.FixedUpdate), otherwise returns false (Read Only).
            */
            public static get inFixedTimeStep(): boolean;
            public constructor ()
        }
        /** Base class for everything attached to a GameObject.
        */
        class Component extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
            /** The Transform attached to this GameObject.
            */
            public get transform(): UnityEngine.Transform;
            /** The game object this component is attached to. A component is always attached to a game object.
            */
            public get gameObject(): UnityEngine.GameObject;
            /** The tag of this game object.
            */
            public get tag(): string;
            public set tag(value: string);
            /** The non-generic version of this method.
            * @param $type The type of Component to retrieve.
            * @returns A Component of the matching type, otherwise null if no Component is found. 
            */
            public GetComponent ($type: System.Type) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $component The output argument that will contain the component or null.
            * @returns Returns true if the component is found, false otherwise. 
            */
            public TryGetComponent ($type: System.Type, $component: $Ref<UnityEngine.Component>) : boolean
            /** The string-based version of this method.
            * @param $type The name of the type of Component to get.
            * @returns A Component of the matching type, otherwise null if no Component is found. 
            */
            public GetComponent ($type: string) : UnityEngine.Component
            /** This is the non-generic version of this method.
            * @param $t The type of component to search for.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns A Component of the matching type, otherwise null if no Component is found. 
            */
            public GetComponentInChildren ($t: System.Type, $includeInactive: boolean) : UnityEngine.Component
            /** This is the non-generic version of this method.
            * @param $t The type of component to search for.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns A Component of the matching type, otherwise null if no Component is found. 
            */
            public GetComponentInChildren ($t: System.Type) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $t The type of component to search for.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns An array of all found components matching the specified type. 
            */
            public GetComponentsInChildren ($t: System.Type, $includeInactive: boolean) : System.Array$1<UnityEngine.Component>
            public GetComponentsInChildren ($t: System.Type) : System.Array$1<UnityEngine.Component>
            /** The non-generic version of this method.
            * @param $t The type of component to search for.
            * @param $includeInactive Whether to include inactive parent GameObjects in the search.
            * @returns A Component of the matching type, otherwise null if no Component is found. 
            */
            public GetComponentInParent ($t: System.Type, $includeInactive: boolean) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $t The type of component to search for.
            * @param $includeInactive Whether to include inactive parent GameObjects in the search.
            * @returns A Component of the matching type, otherwise null if no Component is found. 
            */
            public GetComponentInParent ($t: System.Type) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $t The type of component to search for.
            * @param $includeInactive Whether to include inactive parent GameObjects in the search.
            * @returns An array of all found components matching the specified type. 
            */
            public GetComponentsInParent ($t: System.Type, $includeInactive: boolean) : System.Array$1<UnityEngine.Component>
            public GetComponentsInParent ($t: System.Type) : System.Array$1<UnityEngine.Component>
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @returns An array containing all matching components of type type. 
            */
            public GetComponents ($type: System.Type) : System.Array$1<UnityEngine.Component>
            public GetComponents ($type: System.Type, $results: System.Collections.Generic.List$1<UnityEngine.Component>) : void
            /** Gets the index of the component on its parent GameObject.
            * @returns The component index. 
            */
            public GetComponentIndex () : number
            /** Checks the GameObject's tag against the defined tag.
            * @param $tag The tag to compare.
            * @returns Returns true if GameObject has same tag. Returns false otherwise. 
            */
            public CompareTag ($tag: string) : boolean
            /** Checks the GameObject's tag against the defined tag.
            * @param $tag A TagHandle representing the tag to compare.
            * @returns Returns true if GameObject has same tag. Returns false otherwise. 
            */
            public CompareTag ($tag: UnityEngine.TagHandle) : boolean
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.
            * @param $methodName Name of method to call.
            * @param $value Optional parameter value for the method.
            * @param $options Should an error be raised if the method does not exist on the target object?
            */
            public SendMessageUpwards ($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.
            * @param $methodName Name of method to call.
            * @param $value Optional parameter value for the method.
            * @param $options Should an error be raised if the method does not exist on the target object?
            */
            public SendMessageUpwards ($methodName: string, $value: any) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.
            * @param $methodName Name of method to call.
            * @param $value Optional parameter value for the method.
            * @param $options Should an error be raised if the method does not exist on the target object?
            */
            public SendMessageUpwards ($methodName: string) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.
            * @param $methodName Name of method to call.
            * @param $value Optional parameter value for the method.
            * @param $options Should an error be raised if the method does not exist on the target object?
            */
            public SendMessageUpwards ($methodName: string, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object.
            * @param $methodName Name of the method to call.
            * @param $value Optional parameter for the method.
            * @param $options Should an error be raised if the target object doesn't implement the method for the message?
            */
            public SendMessage ($methodName: string, $value: any) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object.
            * @param $methodName Name of the method to call.
            * @param $value Optional parameter for the method.
            * @param $options Should an error be raised if the target object doesn't implement the method for the message?
            */
            public SendMessage ($methodName: string) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object.
            * @param $methodName Name of the method to call.
            * @param $value Optional parameter for the method.
            * @param $options Should an error be raised if the target object doesn't implement the method for the message?
            */
            public SendMessage ($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object.
            * @param $methodName Name of the method to call.
            * @param $value Optional parameter for the method.
            * @param $options Should an error be raised if the target object doesn't implement the method for the message?
            */
            public SendMessage ($methodName: string, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children.
            * @param $methodName Name of the method to call.
            * @param $parameter Optional parameter to pass to the method (can be any value).
            * @param $options Should an error be raised if the method does not exist for a given target object?
            */
            public BroadcastMessage ($methodName: string, $parameter: any, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children.
            * @param $methodName Name of the method to call.
            * @param $parameter Optional parameter to pass to the method (can be any value).
            * @param $options Should an error be raised if the method does not exist for a given target object?
            */
            public BroadcastMessage ($methodName: string, $parameter: any) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children.
            * @param $methodName Name of the method to call.
            * @param $parameter Optional parameter to pass to the method (can be any value).
            * @param $options Should an error be raised if the method does not exist for a given target object?
            */
            public BroadcastMessage ($methodName: string) : void
            /** Calls the method named methodName on every MonoBehaviour in this game object or any of its children.
            * @param $methodName Name of the method to call.
            * @param $parameter Optional parameter to pass to the method (can be any value).
            * @param $options Should an error be raised if the method does not exist for a given target object?
            */
            public BroadcastMessage ($methodName: string, $options: UnityEngine.SendMessageOptions) : void
            public constructor ()
        }
        /** Position, rotation and scale of an object.
        */
        class Transform extends UnityEngine.Component implements System.Collections.IEnumerable
        {
            protected [__keep_incompatibility]: never;
            /** The world space position of the Transform.
            */
            public get position(): UnityEngine.Vector3;
            public set position(value: UnityEngine.Vector3);
            /** Position of the transform relative to the parent transform.
            */
            public get localPosition(): UnityEngine.Vector3;
            public set localPosition(value: UnityEngine.Vector3);
            /** The rotation as Euler angles in degrees.
            */
            public get eulerAngles(): UnityEngine.Vector3;
            public set eulerAngles(value: UnityEngine.Vector3);
            /** The rotation as Euler angles in degrees relative to the parent transform's rotation.
            */
            public get localEulerAngles(): UnityEngine.Vector3;
            public set localEulerAngles(value: UnityEngine.Vector3);
            /** The red axis of the transform in world space.
            */
            public get right(): UnityEngine.Vector3;
            public set right(value: UnityEngine.Vector3);
            /** The green axis of the transform in world space.
            */
            public get up(): UnityEngine.Vector3;
            public set up(value: UnityEngine.Vector3);
            /** Returns a normalized vector representing the blue axis of the transform in world space.
            */
            public get forward(): UnityEngine.Vector3;
            public set forward(value: UnityEngine.Vector3);
            /** A Quaternion that stores the rotation of the Transform in world space.
            */
            public get rotation(): UnityEngine.Quaternion;
            public set rotation(value: UnityEngine.Quaternion);
            /** The rotation of the transform relative to the transform rotation of the parent.
            */
            public get localRotation(): UnityEngine.Quaternion;
            public set localRotation(value: UnityEngine.Quaternion);
            /** The scale of the transform relative to the GameObjects parent.
            */
            public get localScale(): UnityEngine.Vector3;
            public set localScale(value: UnityEngine.Vector3);
            /** The parent of the transform.
            */
            public get parent(): UnityEngine.Transform;
            public set parent(value: UnityEngine.Transform);
            /** Matrix that transforms a point from world space into local space (Read Only).
            */
            public get worldToLocalMatrix(): UnityEngine.Matrix4x4;
            /** Matrix that transforms a point from local space into world space (Read Only).
            */
            public get localToWorldMatrix(): UnityEngine.Matrix4x4;
            /** Returns the topmost transform in the hierarchy.
            */
            public get root(): UnityEngine.Transform;
            /** The number of children the parent Transform has.
            */
            public get childCount(): number;
            /** The global scale of the object (Read Only).
            */
            public get lossyScale(): UnityEngine.Vector3;
            /** Has the transform changed since the last time the flag was set to 'false'?
            */
            public get hasChanged(): boolean;
            public set hasChanged(value: boolean);
            /** The transform capacity of the transform's hierarchy data structure.
            */
            public get hierarchyCapacity(): number;
            public set hierarchyCapacity(value: number);
            /** The number of transforms in the transform's hierarchy data structure.
            */
            public get hierarchyCount(): number;
            /** Set the parent of the transform.
            * @param $parent The parent Transform to use.
            * @param $worldPositionStays If true, the parent-relative position, scale and rotation are modified such that the object keeps the same world space position, rotation and scale as before.
            */
            public SetParent ($p: UnityEngine.Transform) : void
            /** Set the parent of the transform.
            * @param $parent The parent Transform to use.
            * @param $worldPositionStays If true, the parent-relative position, scale and rotation are modified such that the object keeps the same world space position, rotation and scale as before.
            */
            public SetParent ($parent: UnityEngine.Transform, $worldPositionStays: boolean) : void
            /** Sets the world space position and rotation of the Transform component.
            */
            public SetPositionAndRotation ($position: UnityEngine.Vector3, $rotation: UnityEngine.Quaternion) : void
            /** Sets the position and rotation of the Transform component in local space (i.e. relative to its parent transform).
            */
            public SetLocalPositionAndRotation ($localPosition: UnityEngine.Vector3, $localRotation: UnityEngine.Quaternion) : void
            /** Gets the position and rotation of the Transform component in world space.
            */
            public GetPositionAndRotation ($position: $Ref<UnityEngine.Vector3>, $rotation: $Ref<UnityEngine.Quaternion>) : void
            /** Gets the position and rotation of the Transform component in local space (that is, relative to its parent transform).
            */
            public GetLocalPositionAndRotation ($localPosition: $Ref<UnityEngine.Vector3>, $localRotation: $Ref<UnityEngine.Quaternion>) : void
            /** Moves the transform in the direction and distance of translation.
            */
            public Translate ($translation: UnityEngine.Vector3, $relativeTo: UnityEngine.Space) : void
            /** Moves the transform in the direction and distance of translation.
            */
            public Translate ($translation: UnityEngine.Vector3) : void
            /** Moves the transform by x along the x axis, y along the y axis, and z along the z axis.
            */
            public Translate ($x: number, $y: number, $z: number, $relativeTo: UnityEngine.Space) : void
            /** Moves the transform by x along the x axis, y along the y axis, and z along the z axis.
            */
            public Translate ($x: number, $y: number, $z: number) : void
            /** Moves the transform in the direction and distance of translation.
            */
            public Translate ($translation: UnityEngine.Vector3, $relativeTo: UnityEngine.Transform) : void
            /** Moves the transform by x along the x axis, y along the y axis, and z along the z axis.
            */
            public Translate ($x: number, $y: number, $z: number, $relativeTo: UnityEngine.Transform) : void
            /** Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order).
            * @param $eulers The rotation to apply in euler angles.
            * @param $relativeTo Determines whether to rotate the GameObject either locally to  the GameObject or relative to the Scene in world space.
            */
            public Rotate ($eulers: UnityEngine.Vector3, $relativeTo: UnityEngine.Space) : void
            /** Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that order).
            * @param $eulers The rotation to apply in euler angles.
            */
            public Rotate ($eulers: UnityEngine.Vector3) : void
            /** The implementation of this method applies a rotation of zAngle degrees around the z axis, xAngle degrees around the x axis, and yAngle degrees around the y axis (in that order).
            * @param $xAngle Degrees to rotate the GameObject around the X axis.
            * @param $yAngle Degrees to rotate the GameObject around the Y axis.
            * @param $zAngle Degrees to rotate the GameObject around the Z axis.
            * @param $relativeTo Determines whether to rotate the GameObject either locally to the GameObject or relative to the Scene in world space.
            */
            public Rotate ($xAngle: number, $yAngle: number, $zAngle: number, $relativeTo: UnityEngine.Space) : void
            /** The implementation of this method applies a rotation of zAngle degrees around the z axis, xAngle degrees around the x axis, and yAngle degrees around the y axis (in that order).
            * @param $xAngle Degrees to rotate the GameObject around the X axis.
            * @param $yAngle Degrees to rotate the GameObject around the Y axis.
            * @param $zAngle Degrees to rotate the GameObject around the Z axis.
            */
            public Rotate ($xAngle: number, $yAngle: number, $zAngle: number) : void
            /** Rotates the object around the given axis by the number of degrees defined by the given angle.
            * @param $axis The axis to apply rotation to.
            * @param $angle The degrees of rotation to apply.
            * @param $relativeTo Determines whether to rotate the GameObject either locally to the GameObject or relative to the Scene in world space.
            */
            public Rotate ($axis: UnityEngine.Vector3, $angle: number, $relativeTo: UnityEngine.Space) : void
            /** Rotates the object around the given axis by the number of degrees defined by the given angle.
            * @param $axis The axis to apply rotation to.
            * @param $angle The degrees of rotation to apply.
            */
            public Rotate ($axis: UnityEngine.Vector3, $angle: number) : void
            /** Rotates the transform about axis passing through point in world coordinates by angle degrees.
            */
            public RotateAround ($point: UnityEngine.Vector3, $axis: UnityEngine.Vector3, $angle: number) : void
            /** Rotates the transform so the forward vector points at target's current position.
            * @param $target Object to point towards.
            * @param $worldUp Vector specifying the upward direction.
            */
            public LookAt ($target: UnityEngine.Transform, $worldUp: UnityEngine.Vector3) : void
            /** Rotates the transform so the forward vector points at target's current position.
            * @param $target Object to point towards.
            * @param $worldUp Vector specifying the upward direction.
            */
            public LookAt ($target: UnityEngine.Transform) : void
            /** Rotates the transform so the forward vector points at worldPosition.
            * @param $worldPosition Point to look at.
            * @param $worldUp Vector specifying the upward direction.
            */
            public LookAt ($worldPosition: UnityEngine.Vector3, $worldUp: UnityEngine.Vector3) : void
            /** Rotates the transform so the forward vector points at worldPosition.
            * @param $worldPosition Point to look at.
            * @param $worldUp Vector specifying the upward direction.
            */
            public LookAt ($worldPosition: UnityEngine.Vector3) : void
            /** Transforms direction from local space to world space.
            */
            public TransformDirection ($direction: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Transforms direction x, y, z from local space to world space.
            */
            public TransformDirection ($x: number, $y: number, $z: number) : UnityEngine.Vector3
            /** Transforms a direction from world space to local space. The opposite of Transform.TransformDirection.
            */
            public InverseTransformDirection ($direction: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Transforms the direction x, y, z from world space to local space. The opposite of Transform.TransformDirection.
            */
            public InverseTransformDirection ($x: number, $y: number, $z: number) : UnityEngine.Vector3
            /** Transforms vector from local space to world space.
            */
            public TransformVector ($vector: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Transforms vector x, y, z from local space to world space.
            */
            public TransformVector ($x: number, $y: number, $z: number) : UnityEngine.Vector3
            /** Transforms a vector from world space to local space. The opposite of Transform.TransformVector.
            */
            public InverseTransformVector ($vector: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Transforms the vector x, y, z from world space to local space. The opposite of Transform.TransformVector.
            */
            public InverseTransformVector ($x: number, $y: number, $z: number) : UnityEngine.Vector3
            /** Transforms position from local space to world space.
            */
            public TransformPoint ($position: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Transforms the position x, y, z from local space to world space.
            */
            public TransformPoint ($x: number, $y: number, $z: number) : UnityEngine.Vector3
            /** Transforms position from world space to local space.
            */
            public InverseTransformPoint ($position: UnityEngine.Vector3) : UnityEngine.Vector3
            /** Transforms the position x, y, z from world space to local space.
            */
            public InverseTransformPoint ($x: number, $y: number, $z: number) : UnityEngine.Vector3
            /** Unparents all children.
            */
            public DetachChildren () : void
            /** Move the transform to the start of the local transform list.
            */
            public SetAsFirstSibling () : void
            /** Move the transform to the end of the local transform list.
            */
            public SetAsLastSibling () : void
            /** Sets the sibling index.
            * @param $index Index to set.
            */
            public SetSiblingIndex ($index: number) : void
            /** Gets the sibling index.
            */
            public GetSiblingIndex () : number
            /** Finds a child by name n and returns it.
            * @param $n The search string, either the name of an immediate child or a hierarchy path for finding a descendent.
            * @returns The found child transform. Null if child with matching name isn't found. 
            */
            public Find ($n: string) : UnityEngine.Transform
            /** Is this transform a child of parent?
            */
            public IsChildOf ($parent: UnityEngine.Transform) : boolean
            public GetEnumerator () : System.Collections.IEnumerator
            /** Returns a transform child by index.
            * @param $index Index of the child transform to return. Must be smaller than Transform.childCount.
            * @returns Transform child by index. 
            */
            public GetChild ($index: number) : UnityEngine.Transform
        }
        /** Quaternions are used to represent rotations.
        */
        class Quaternion extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Quaternion>
        {
            protected [__keep_incompatibility]: never;
        }
        /** A standard 4x4 transformation matrix.
        */
        class Matrix4x4 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Matrix4x4>
        {
            protected [__keep_incompatibility]: never;
        }
        /** The coordinate spaces in which to apply transformation to a GameObject.
        */
        enum Space
        { World = 0, Self = 1 }
        /** Base class for all objects that can exist in a scene. Add components to a GameObject to control its appearance and behavior.
        */
        class GameObject extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
            /** The Transform attached to the GameObject (Read Only).
            */
            public get transform(): UnityEngine.Transform;
            /** Integer identifying the layer the GameObject is assigned to.
            */
            public get layer(): number;
            public set layer(value: number);
            /** The local active state of the GameObject. True if active, false if inactive. (Read Only)
            */
            public get activeSelf(): boolean;
            /** The active state of the GameObject in the Scene hierarchy. True if active, false if inactive. (Read Only)
            */
            public get activeInHierarchy(): boolean;
            /** Whether there are any Static Editor Flags set for the GameObject.
            */
            public get isStatic(): boolean;
            public set isStatic(value: boolean);
            /** The tag assigned to the GameObject.
            */
            public get tag(): string;
            public set tag(value: string);
            /** The Scene that contains the GameObject.
            */
            public get scene(): UnityEngine.SceneManagement.Scene;
            /** The Scene culling mask defined for the GameObject. (Read Only)
            */
            public get sceneCullingMask(): bigint;
            public get gameObject(): UnityEngine.GameObject;
            /** Creates a GameObject of the specified PrimtiveType with a mesh renderer and appropriate collider.
            * @param $type The type of primitive object to create, specified as a member of the PrimitiveType enum.
            */
            public static CreatePrimitive ($type: UnityEngine.PrimitiveType) : UnityEngine.GameObject
            /** Retrieves a reference to a component of specified type, by providing the component type as a method parameter.
            * @param $type The type of component to search for, specified as a Type object.
            * @returns A reference to a component of the specified type, returned as a Component type. If no component is found, returns null. 
            */
            public GetComponent ($type: System.Type) : UnityEngine.Component
            /** Retrieves a reference to a component of the specified type, by providing the name of the component type as a method parameter.
            * @param $type The name of the type of component to search for, specified as a string.
            * @returns A reference to a component of the specified type, returned as a Component type. If no component is found, returns null. 
            */
            public GetComponent ($type: string) : UnityEngine.Component
            /** This is the non-generic version of this method.
            * @param $type The type of Component to retrieve.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns A component of the matching type, if found. 
            */
            public GetComponentInChildren ($type: System.Type, $includeInactive: boolean) : UnityEngine.Component
            /** This is the non-generic version of this method.
            * @param $type The type of Component to retrieve.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns A component of the matching type, if found. 
            */
            public GetComponentInChildren ($type: System.Type) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $includeInactive Whether to include inactive parent GameObjects in the search.
            * @returns A Component of the matching type, otherwise null if no matching Component is found. 
            */
            public GetComponentInParent ($type: System.Type, $includeInactive: boolean) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $includeInactive Whether to include inactive parent GameObjects in the search.
            * @returns A Component of the matching type, otherwise null if no matching Component is found. 
            */
            public GetComponentInParent ($type: System.Type) : UnityEngine.Component
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @returns An array containing all matching components of type type. 
            */
            public GetComponents ($type: System.Type) : System.Array$1<UnityEngine.Component>
            public GetComponents ($type: System.Type, $results: System.Collections.Generic.List$1<UnityEngine.Component>) : void
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns An array of all found components matching the specified type. 
            */
            public GetComponentsInChildren ($type: System.Type) : System.Array$1<UnityEngine.Component>
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $includeInactive Whether to include inactive child GameObjects in the search.
            * @returns An array of all found components matching the specified type. 
            */
            public GetComponentsInChildren ($type: System.Type, $includeInactive: boolean) : System.Array$1<UnityEngine.Component>
            public GetComponentsInParent ($type: System.Type) : System.Array$1<UnityEngine.Component>
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $includeInactive Whether to include inactive parent GameObjects in the search.
            * @returns An array of all found components matching the specified type. 
            */
            public GetComponentsInParent ($type: System.Type, $includeInactive: boolean) : System.Array$1<UnityEngine.Component>
            /** The non-generic version of this method.
            * @param $type The type of component to search for.
            * @param $component The out parameter that will contain the component or null.
            * @returns Returns true if the component is found, false otherwise. 
            */
            public TryGetComponent ($type: System.Type, $component: $Ref<UnityEngine.Component>) : boolean
            /** Retrieves the first active GameObject tagged with the specified tag. Returns null if no GameObject has the tag.
            * @param $tag The tag to search for.
            */
            public static FindWithTag ($tag: string) : UnityEngine.GameObject
            public static FindGameObjectsWithTag ($tag: string, $results: System.Collections.Generic.List$1<UnityEngine.GameObject>) : void
            public SendMessageUpwards ($methodName: string, $options: UnityEngine.SendMessageOptions) : void
            public SendMessage ($methodName: string, $options: UnityEngine.SendMessageOptions) : void
            public BroadcastMessage ($methodName: string, $options: UnityEngine.SendMessageOptions) : void
            /** Adds a component of the specified type to the GameObject.
            */
            public AddComponent ($componentType: System.Type) : UnityEngine.Component
            /** Retrieves the total number of components currently attached to the GameObject.
            * @returns The number of components on the GameObject as an Integer value. 
            */
            public GetComponentCount () : number
            /** Retrieves a reference to a component of type T at a specific index on the specified GameObject.
            * @param $index The index position in the array of components at which to find the requested object.
            * @returns A reference to a component of type T at the specified index. If no component is found at the specified index, returns null. 
            */
            public GetComponentAtIndex ($index: number) : UnityEngine.Component
            /** Retrieves the index of the specified component in the array of components attached to the GameObject.
            * @param $component The component to search for.
            * @returns The index of the specified Component if it exists. Otherwise, returns -1. 
            */
            public GetComponentIndex ($component: UnityEngine.Component) : number
            /** Activates or deactivates the GameObject locally, according to the value of the supplied parameter.
            * @param $value The active state to set, where true sets the GameObject to active and false sets it to inactive.
            */
            public SetActive ($value: boolean) : void
            /** Checks if the specified tag is attached to the GameObject.
            * @param $tag The tag to check for on the GameObject.
            * @returns true if the GameObject has the given tag, false otherwise. 
            */
            public CompareTag ($tag: string) : boolean
            /** Checks if the specified tag is attached to the GameObject.
            * @param $tag A TagHandle representing the tag to check for on the GameObject.
            * @returns true if the GameObject has the given tag, false otherwise. 
            */
            public CompareTag ($tag: UnityEngine.TagHandle) : boolean
            public static FindGameObjectWithTag ($tag: string) : UnityEngine.GameObject
            /** Retrieves an array of all active GameObjects tagged with the specified tag. Returns an empty array if no GameObjects have the tag.
            * @param $tag The name of the tag to search for GameObjects by.
            */
            public static FindGameObjectsWithTag ($tag: string) : System.Array$1<UnityEngine.GameObject>
            /** Calls the specified method on every MonoBehaviour attached to the GameObject and on every ancestor of the behaviour.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $value An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public SendMessageUpwards ($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject and on every ancestor of the behaviour.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $value An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public SendMessageUpwards ($methodName: string, $value: any) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject and on every ancestor of the behaviour.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $value An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public SendMessageUpwards ($methodName: string) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $value An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public SendMessage ($methodName: string, $value: any, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $value An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public SendMessage ($methodName: string, $value: any) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $value An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public SendMessage ($methodName: string) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject or any of its children.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $parameter An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public BroadcastMessage ($methodName: string, $parameter: any, $options: UnityEngine.SendMessageOptions) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject or any of its children.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $parameter An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public BroadcastMessage ($methodName: string, $parameter: any) : void
            /** Calls the specified method on every MonoBehaviour attached to the GameObject or any of its children.
            * @param $methodName The name of the MonoBehaviour method to call.
            * @param $parameter An optional parameter value to pass to the called method.
            * @param $options Whether an error should be raised if the method doesn't exist on the target object.
            */
            public BroadcastMessage ($methodName: string) : void
            /** Finds and returns a GameObject with the specified name.
            * @param $name The name of the GameObject to find.
            */
            public static Find ($name: string) : UnityEngine.GameObject
            public static SetGameObjectsActive ($instanceIDs: Unity.Collections.NativeArray$1<number>, $active: boolean) : void
            public static InstantiateGameObjects ($sourceInstanceID: number, $count: number, $newInstanceIDs: Unity.Collections.NativeArray$1<number>, $newTransformInstanceIDs: Unity.Collections.NativeArray$1<number>, $destinationScene?: UnityEngine.SceneManagement.Scene) : void
            /** Retrieves the Scene which contains the GameObject with the specified instance ID.
            * @param $instanceID The instance ID of the GameObject.
            * @returns The Scene the GameObject with the specified instance ID is part of. 
            */
            public static GetScene ($instanceID: number) : UnityEngine.SceneManagement.Scene
            public constructor ($name: string)
            public constructor ()
            public constructor ($name: string, ...components: System.Type[])
        }
        /** A handle to one of the tag values that can be applied to a GameObject.
        */
        class TagHandle extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        /** Options for how to send a message.
        */
        enum SendMessageOptions
        { RequireReceiver = 0, DontRequireReceiver = 1 }
        /** The various primitives that can be created using the GameObject.CreatePrimitive function.
        */
        enum PrimitiveType
        { Sphere = 0, Capsule = 1, Cylinder = 2, Cube = 3, Plane = 4, Quad = 5 }
        /** Asynchronous instantiate operation on UnityEngine.Object type.
        */
        class AsyncInstantiateOperation extends UnityEngine.AsyncOperation
        {
            protected [__keep_incompatibility]: never;
        }
        class AsyncInstantiateOperation$1<T> extends UnityEngine.AsyncInstantiateOperation
        {
            protected [__keep_incompatibility]: never;
        }
        /** Options to specify if and how to sort objects returned by a function.
        */
        enum FindObjectsSortMode
        { None = 0, InstanceID = 1 }
        /** Options to control whether object find functions return inactive objects.
        */
        enum FindObjectsInactive
        { Exclude = 0, Include = 1 }
        /** Bit mask that controls object destruction, saving and visibility in inspectors.
        */
        enum HideFlags
        { None = 0, HideInHierarchy = 1, HideInInspector = 2, DontSaveInEditor = 4, NotEditable = 8, DontSaveInBuild = 16, DontUnloadUnusedAsset = 32, DontSave = 52, HideAndDontSave = 61 }
        /** Script interface for the Built-in Particle System. Unity's powerful and versatile particle system implementation.
        */
        class ParticleSystem extends UnityEngine.Component
        {
            protected [__keep_incompatibility]: never;
            /** Determines whether the Particle System is playing.
            */
            public get isPlaying(): boolean;
            /** Determines whether the Particle System is emitting particles. A Particle System may stop emitting when its emission module has finished, it has been paused or if the system has been stopped using ParticleSystem.Stop|Stop with the ParticleSystemStopBehavior.StopEmitting|StopEmitting flag. Resume emitting by calling ParticleSystem.Play|Play.
            */
            public get isEmitting(): boolean;
            /** Determines whether the Particle System is in the stopped state.
            */
            public get isStopped(): boolean;
            /** Determines whether the Particle System is paused.
            */
            public get isPaused(): boolean;
            /** The current number of particles (Read Only). The number doesn't include particles of child Particle Systems
            */
            public get particleCount(): number;
            /** Playback position in seconds.
            */
            public get time(): number;
            public set time(value: number);
            /** Total playback time in seconds, including the Start Delay setting.
            */
            public get totalTime(): number;
            /** Override the random seed used for the Particle System emission.
            */
            public get randomSeed(): number;
            public set randomSeed(value: number);
            /** Controls whether the Particle System uses an automatically-generated random number to seed the random number generator.
            */
            public get useAutoRandomSeed(): boolean;
            public set useAutoRandomSeed(value: boolean);
            /** Determines whether this system supports Procedural Simulation.
            */
            public get proceduralSimulationSupported(): boolean;
            /** Determines whether the Particle System rotates its particles around only the Z axis, or whether the system specifies separate values for the X, Y and Z axes.
            */
            public get has3DParticleRotations(): boolean;
            /** Determines whether the Particle System uses a single value for the width and height (and depth, when using meshes), or if the system specifies different values for each axis.
            */
            public get hasNonUniformParticleSizes(): boolean;
            /** Access the main Particle System settings.
            */
            public get main(): UnityEngine.ParticleSystem.MainModule;
            /** Script interface for the EmissionModule of a Particle System.
            */
            public get emission(): UnityEngine.ParticleSystem.EmissionModule;
            /** Script interface for the ShapeModule of a Particle System. 
            */
            public get shape(): UnityEngine.ParticleSystem.ShapeModule;
            /** Script interface for the VelocityOverLifetimeModule of a Particle System.
            */
            public get velocityOverLifetime(): UnityEngine.ParticleSystem.VelocityOverLifetimeModule;
            /** Script interface for the LimitVelocityOverLifetimeModule of a Particle System. .
            */
            public get limitVelocityOverLifetime(): UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule;
            /** Script interface for the InheritVelocityModule of a Particle System.
            */
            public get inheritVelocity(): UnityEngine.ParticleSystem.InheritVelocityModule;
            /** Script interface for the Particle System Lifetime By Emitter Speed module.
            */
            public get lifetimeByEmitterSpeed(): UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule;
            /** Script interface for the ForceOverLifetimeModule of a Particle System.
            */
            public get forceOverLifetime(): UnityEngine.ParticleSystem.ForceOverLifetimeModule;
            /** Script interface for the ColorOverLifetimeModule of a Particle System.
            */
            public get colorOverLifetime(): UnityEngine.ParticleSystem.ColorOverLifetimeModule;
            /** Script interface for the ColorByLifetimeModule of a Particle System.
            */
            public get colorBySpeed(): UnityEngine.ParticleSystem.ColorBySpeedModule;
            /** Script interface for the SizeOverLifetimeModule of a Particle System. 
            */
            public get sizeOverLifetime(): UnityEngine.ParticleSystem.SizeOverLifetimeModule;
            /** Script interface for the SizeBySpeedModule of a Particle System.
            */
            public get sizeBySpeed(): UnityEngine.ParticleSystem.SizeBySpeedModule;
            /** Script interface for the RotationOverLifetimeModule of a Particle System.
            */
            public get rotationOverLifetime(): UnityEngine.ParticleSystem.RotationOverLifetimeModule;
            /** Script interface for the RotationBySpeedModule of a Particle System.
            */
            public get rotationBySpeed(): UnityEngine.ParticleSystem.RotationBySpeedModule;
            /** Script interface for the ExternalForcesModule of a Particle System.
            */
            public get externalForces(): UnityEngine.ParticleSystem.ExternalForcesModule;
            /** Script interface for the NoiseModule of a Particle System.
            */
            public get noise(): UnityEngine.ParticleSystem.NoiseModule;
            /** Script interface for the CollisionModule of a Particle System.
            */
            public get collision(): UnityEngine.ParticleSystem.CollisionModule;
            /** Script interface for the TriggerModule of a Particle System.
            */
            public get trigger(): UnityEngine.ParticleSystem.TriggerModule;
            /** Script interface for the SubEmittersModule of a Particle System.
            */
            public get subEmitters(): UnityEngine.ParticleSystem.SubEmittersModule;
            /** Script interface for the TextureSheetAnimationModule of a Particle System.
            */
            public get textureSheetAnimation(): UnityEngine.ParticleSystem.TextureSheetAnimationModule;
            /** Script interface for the LightsModule of a Particle System.
            */
            public get lights(): UnityEngine.ParticleSystem.LightsModule;
            /** Script interface for the TrailsModule of a Particle System.
            */
            public get trails(): UnityEngine.ParticleSystem.TrailModule;
            /** Script interface for the CustomDataModule of a Particle System.
            */
            public get customData(): UnityEngine.ParticleSystem.CustomDataModule;
            public SetParticles ($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number) : void
            public SetParticles ($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number) : void
            public SetParticles ($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>) : void
            public SetParticles ($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number) : void
            public SetParticles ($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number) : void
            public SetParticles ($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>) : void
            public GetParticles ($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number) : number
            public GetParticles ($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>, $size: number) : number
            public GetParticles ($particles: System.Array$1<UnityEngine.ParticleSystem.Particle>) : number
            public GetParticles ($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number, $offset: number) : number
            public GetParticles ($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>, $size: number) : number
            public GetParticles ($particles: Unity.Collections.NativeArray$1<UnityEngine.ParticleSystem.Particle>) : number
            public SetCustomParticleData ($customData: System.Collections.Generic.List$1<UnityEngine.Vector4>, $streamIndex: UnityEngine.ParticleSystemCustomData) : void
            public GetCustomParticleData ($customData: System.Collections.Generic.List$1<UnityEngine.Vector4>, $streamIndex: UnityEngine.ParticleSystemCustomData) : number
            /** Returns all the data that relates to the current internal state of the Particle System.
            * @returns The current internal state of the Particle System. 
            */
            public GetPlaybackState () : UnityEngine.ParticleSystem.PlaybackState
            public SetPlaybackState ($playbackState: UnityEngine.ParticleSystem.PlaybackState) : void
            /** Returns all the data relating to the current internal state of the Particle System Trails.
            * @returns The variable to populate with the Trails that currently belong to the Particle System.. 
            */
            public GetTrails () : UnityEngine.ParticleSystem.Trails
            public GetTrails ($trailData: $Ref<UnityEngine.ParticleSystem.Trails>) : number
            public SetTrails ($trailData: UnityEngine.ParticleSystem.Trails) : void
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it.
            * @param $t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
            * @param $withChildren Fast-forward all child Particle Systems as well.
            * @param $restart Restart and start from the beginning.
            * @param $fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
            */
            public Simulate ($t: number, $withChildren: boolean, $restart: boolean, $fixedTimeStep: boolean) : void
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it.
            * @param $t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
            * @param $withChildren Fast-forward all child Particle Systems as well.
            * @param $restart Restart and start from the beginning.
            * @param $fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
            */
            public Simulate ($t: number, $withChildren: boolean, $restart: boolean) : void
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it.
            * @param $t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
            * @param $withChildren Fast-forward all child Particle Systems as well.
            * @param $restart Restart and start from the beginning.
            * @param $fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
            */
            public Simulate ($t: number, $withChildren: boolean) : void
            /** Fast-forwards the Particle System by simulating particles over the given period of time, then pauses it.
            * @param $t Time period in seconds to advance the ParticleSystem simulation by. If restart is true, the ParticleSystem will be reset to 0 time, and then advanced by this value. If restart is false, the ParticleSystem simulation will be advanced in time from its current state by this value.
            * @param $withChildren Fast-forward all child Particle Systems as well.
            * @param $restart Restart and start from the beginning.
            * @param $fixedTimeStep Only update the system at fixed intervals, based on the value in "Fixed Time" in the Time options.
            */
            public Simulate ($t: number) : void
            /** Starts the Particle System.
            * @param $withChildren Play all child Particle Systems as well.
            */
            public Play ($withChildren: boolean) : void
            /** Starts the Particle System.
            * @param $withChildren Play all child Particle Systems as well.
            */
            public Play () : void
            /** Pauses the system so no new particles are emitted and the existing particles are not updated.
            * @param $withChildren Pause all child Particle Systems as well.
            */
            public Pause ($withChildren: boolean) : void
            /** Pauses the system so no new particles are emitted and the existing particles are not updated.
            * @param $withChildren Pause all child Particle Systems as well.
            */
            public Pause () : void
            /** Stops playing the Particle System using the supplied stop behaviour.
            * @param $withChildren Stop all child Particle Systems as well.
            * @param $stopBehavior Stop emitting or stop emitting and clear the system.
            */
            public Stop ($withChildren: boolean, $stopBehavior: UnityEngine.ParticleSystemStopBehavior) : void
            /** Stops playing the Particle System using the supplied stop behaviour.
            * @param $withChildren Stop all child Particle Systems as well.
            * @param $stopBehavior Stop emitting or stop emitting and clear the system.
            */
            public Stop ($withChildren: boolean) : void
            /** Stops playing the Particle System using the supplied stop behaviour.
            * @param $withChildren Stop all child Particle Systems as well.
            * @param $stopBehavior Stop emitting or stop emitting and clear the system.
            */
            public Stop () : void
            /** Remove all particles in the Particle System.
            * @param $withChildren Clear all child Particle Systems as well.
            */
            public Clear ($withChildren: boolean) : void
            /** Remove all particles in the Particle System.
            * @param $withChildren Clear all child Particle Systems as well.
            */
            public Clear () : void
            /** Does the Particle System contain any live particles, or will it produce more?
            * @param $withChildren Check all child Particle Systems as well.
            * @returns True if the Particle System contains live particles or is still creating new particles. False if the Particle System has stopped emitting particles and all particles are dead. 
            */
            public IsAlive ($withChildren: boolean) : boolean
            /** Does the Particle System contain any live particles, or will it produce more?
            * @param $withChildren Check all child Particle Systems as well.
            * @returns True if the Particle System contains live particles or is still creating new particles. False if the Particle System has stopped emitting particles and all particles are dead. 
            */
            public IsAlive () : boolean
            /** Emit count particles immediately.
            * @param $count Number of particles to emit.
            */
            public Emit ($count: number) : void
            public Emit ($emitParams: UnityEngine.ParticleSystem.EmitParams, $count: number) : void
            /** Triggers the specified sub emitter on all particles of the Particle System.
            * @param $subEmitterIndex Index of the sub emitter to trigger.
            */
            public TriggerSubEmitter ($subEmitterIndex: number) : void
            public TriggerSubEmitter ($subEmitterIndex: number, $particle: $Ref<UnityEngine.ParticleSystem.Particle>) : void
            public TriggerSubEmitter ($subEmitterIndex: number, $particles: System.Collections.Generic.List$1<UnityEngine.ParticleSystem.Particle>) : void
            /** Reset the cache of reserved graphics memory used for efficient rendering of Particle Systems.
            */
            public static ResetPreMappedBufferMemory () : void
            /** Limits the amount of graphics memory Unity reserves for efficient rendering of Particle Systems.
            * @param $vertexBuffersCount The maximum number of cached vertex buffers.
            * @param $indexBuffersCount The maximum number of cached index buffers.
            */
            public static SetMaximumPreMappedBufferCounts ($vertexBuffersCount: number, $indexBuffersCount: number) : void
            /** Ensures that the ParticleSystemJobs.ParticleSystemJobData._axisOfRotations|axisOfRotations particle attribute array is allocated.
            */
            public AllocateAxisOfRotationAttribute () : void
            /** Ensures that the ParticleSystemJobs.ParticleSystemJobData._meshIndices|meshIndices particle attribute array is allocated.
            */
            public AllocateMeshIndexAttribute () : void
            /** Ensures that the ParticleSystemJobs.ParticleSystemJobData.customData1|customData1 and ParticleSystemJobs.ParticleSystemJobData.customData1|customData2 particle attribute arrays are allocated.
            * @param $stream The custom data stream to allocate.
            */
            public AllocateCustomDataAttribute ($stream: UnityEngine.ParticleSystemCustomData) : void
            public constructor ()
        }
        /** Representation of RGBA colors in 32 bit format.
        */
        class Color32 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Color32>
        {
            protected [__keep_incompatibility]: never;
        }
        /** The space to simulate particles in.
        */
        enum ParticleSystemSimulationSpace
        { Local = 0, World = 1, Custom = 2 }
        /** Control how particle systems apply transform scale.
        */
        enum ParticleSystemScalingMode
        { Hierarchy = 0, Local = 1, Shape = 2 }
        /** Representation of four-dimensional vectors.
        */
        class Vector4 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector4>
        {
            protected [__keep_incompatibility]: never;
        }
        /** Which stream of custom particle data to set.
        */
        enum ParticleSystemCustomData
        { Custom1 = 0, Custom2 = 1 }
        /** The behavior to apply when calling ParticleSystem.Stop|Stop.
        */
        enum ParticleSystemStopBehavior
        { StopEmittingAndClear = 0, StopEmitting = 1 }
        /** Behaviours are Components that can be enabled or disabled.
        */
        class Behaviour extends UnityEngine.Component
        {
            protected [__keep_incompatibility]: never;
            /** Enabled Behaviours are Updated, disabled Behaviours are not.
            */
            public get enabled(): boolean;
            public set enabled(value: boolean);
            /** Reports whether a GameObject and its associated Behaviour is active and enabled.
            */
            public get isActiveAndEnabled(): boolean;
            public constructor ()
        }
        /** Element that can be used for screen rendering.
        */
        class Canvas extends UnityEngine.Behaviour
        {
            protected [__keep_incompatibility]: never;
            /** Is the Canvas in World or Overlay mode?
            */
            public get renderMode(): UnityEngine.RenderMode;
            public set renderMode(value: UnityEngine.RenderMode);
            /** Is this the root Canvas?
            */
            public get isRootCanvas(): boolean;
            /** Get the render rect for the Canvas.
            */
            public get pixelRect(): UnityEngine.Rect;
            /** Scales the entire canvas, ensuring it fits the screen. It only applies when Canvas.renderMode is set to Screen Space.
            */
            public get scaleFactor(): number;
            public set scaleFactor(value: number);
            /** The number of pixels per unit that is considered the default.
            */
            public get referencePixelsPerUnit(): number;
            public set referencePixelsPerUnit(value: number);
            /** Allows for nested canvases to override pixelPerfect settings inherited from parent canvases.
            */
            public get overridePixelPerfect(): boolean;
            public set overridePixelPerfect(value: boolean);
            /** Should the Canvas vertex color always be in gamma space before passing to the UI shaders in linear color space work flow.
            */
            public get vertexColorAlwaysGammaSpace(): boolean;
            public set vertexColorAlwaysGammaSpace(value: boolean);
            /** Forces pixel alignment for elements in the canvas. It only applies when Canvas.renderMode is set to Screen Space.
            */
            public get pixelPerfect(): boolean;
            public set pixelPerfect(value: boolean);
            /** How far away from the camera is the Canvas generated? It only applies when Canvas.renderMode is set to RenderMode.ScreenSpaceCamera.
            */
            public get planeDistance(): number;
            public set planeDistance(value: number);
            /** The render order in which the canvas is being emitted to the Scene. (Read Only)
            */
            public get renderOrder(): number;
            /** Allows for nested canvases to override the Canvas.sortingOrder from parent canvases.
            */
            public get overrideSorting(): boolean;
            public set overrideSorting(value: boolean);
            /** Canvas' order within a sorting layer.
            */
            public get sortingOrder(): number;
            public set sortingOrder(value: number);
            /** For Overlay mode, display index on which the UI canvas will appear.
            */
            public get targetDisplay(): number;
            public set targetDisplay(value: number);
            /** Unique ID of the Canvas' sorting layer.
            */
            public get sortingLayerID(): number;
            public set sortingLayerID(value: number);
            /** Cached calculated value based upon SortingLayerID.
            */
            public get cachedSortingLayerValue(): number;
            /** Get or set the mask of additional shader channels to be used when creating the Canvas mesh.
            */
            public get additionalShaderChannels(): UnityEngine.AdditionalCanvasShaderChannels;
            public set additionalShaderChannels(value: UnityEngine.AdditionalCanvasShaderChannels);
            /** Name of the Canvas' sorting layer.
            */
            public get sortingLayerName(): string;
            public set sortingLayerName(value: string);
            /** Returns the Canvas closest to root, by checking through each parent and returning the last canvas found. If no other canvas is found then the canvas will return itself.
            */
            public get rootCanvas(): UnityEngine.Canvas;
            /** Returns the canvas display size based on the selected render mode and target display.
            */
            public get renderingDisplaySize(): UnityEngine.Vector2;
            /** Should the Canvas size be updated based on the render target when a manual Camera.Render call is performed.
            */
            public get updateRectTransformForStandalone(): UnityEngine.StandaloneRenderResize;
            public set updateRectTransformForStandalone(value: UnityEngine.StandaloneRenderResize);
            /** Camera used for sizing the Canvas when in Screen Space - Camera. Also used as the Camera that events will be sent through for a World Space Canvas.
            */
            public get worldCamera(): UnityEngine.Camera;
            public set worldCamera(value: UnityEngine.Camera);
            /** The normalized grid size that the canvas will split the renderable area into.
            */
            public get normalizedSortingGridSize(): number;
            public set normalizedSortingGridSize(value: number);
            public static add_preWillRenderCanvases ($value: UnityEngine.Canvas.WillRenderCanvases) : void
            public static remove_preWillRenderCanvases ($value: UnityEngine.Canvas.WillRenderCanvases) : void
            public static add_willRenderCanvases ($value: UnityEngine.Canvas.WillRenderCanvases) : void
            public static remove_willRenderCanvases ($value: UnityEngine.Canvas.WillRenderCanvases) : void
            /** Returns the default material that can be used for rendering normal elements on the Canvas.
            */
            public static GetDefaultCanvasMaterial () : UnityEngine.Material
            /** Gets or generates the ETC1 Material.
            * @returns The generated ETC1 Material from the Canvas. 
            */
            public static GetETC1SupportedCanvasMaterial () : UnityEngine.Material
            /** Force all canvases to update their content.
            */
            public static ForceUpdateCanvases () : void
            public constructor ()
        }
        /** RenderMode for the Canvas.
        */
        enum RenderMode
        { ScreenSpaceOverlay = 0, ScreenSpaceCamera = 1, WorldSpace = 2 }
        /** A 2D Rectangle defined by X and Y position, width and height.
        */
        class Rect extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Rect>
        {
            protected [__keep_incompatibility]: never;
        }
        /** Enum mask of possible shader channel properties that can also be included when the Canvas mesh is created.
        */
        enum AdditionalCanvasShaderChannels
        { None = 0, TexCoord1 = 1, TexCoord2 = 2, TexCoord3 = 4, Normal = 8, Tangent = 16 }
        /** Representation of 2D vectors and points.
        */
        class Vector2 extends System.ValueType implements System.IFormattable, System.IEquatable$1<UnityEngine.Vector2>
        {
            protected [__keep_incompatibility]: never;
        }
        /** Enum used to determine if a Canvas should be resized when a manual Camera.Render call is performed.
        */
        enum StandaloneRenderResize
        { Enabled = 0, Disabled = 1 }
        /** A Camera is a device through which the player views the world.
        */
        class Camera extends UnityEngine.Behaviour
        {
            protected [__keep_incompatibility]: never;
        }
        /** The material class.
        */
        class Material extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** MonoBehaviour is a base class that many Unity scripts derive from.
        */
        class MonoBehaviour extends UnityEngine.Behaviour
        {
            protected [__keep_incompatibility]: never;
            /** Cancellation token raised when the MonoBehaviour is destroyed (Read Only).
            */
            public get destroyCancellationToken(): System.Threading.CancellationToken;
            /** Disabling this lets you skip the GUI layout phase.
            */
            public get useGUILayout(): boolean;
            public set useGUILayout(value: boolean);
            /** Returns a boolean value which represents if Start was called.
            */
            public get didStart(): boolean;
            /** Returns a boolean value which represents if Awake was called.
            */
            public get didAwake(): boolean;
            /** Allow a specific instance of a MonoBehaviour to run in edit mode (only available in the editor).
            */
            public get runInEditMode(): boolean;
            public set runInEditMode(value: boolean);
            /** Is any invoke pending on this MonoBehaviour?
            */
            public IsInvoking () : boolean
            /** Cancels all Invoke calls on this MonoBehaviour.
            */
            public CancelInvoke () : void
            /** Invokes the method methodName in time seconds.
            */
            public Invoke ($methodName: string, $time: number) : void
            /** Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
            * @param $methodName The name of a method to invoke.
            * @param $time Start invoking after n seconds.
            * @param $repeatRate Repeat every n seconds.
            */
            public InvokeRepeating ($methodName: string, $time: number, $repeatRate: number) : void
            /** Cancels all Invoke calls with name methodName on this behaviour.
            */
            public CancelInvoke ($methodName: string) : void
            /** Is any invoke on methodName pending?
            */
            public IsInvoking ($methodName: string) : boolean
            /** Starts a coroutine named methodName.
            */
            public StartCoroutine ($methodName: string) : UnityEngine.Coroutine
            /** Starts a coroutine named methodName.
            */
            public StartCoroutine ($methodName: string, $value: any) : UnityEngine.Coroutine
            /** Starts a Coroutine.
            */
            public StartCoroutine ($routine: System.Collections.IEnumerator) : UnityEngine.Coroutine
            /** Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.
            * @param $methodName Name of coroutine.
            * @param $routine Name of the function in code, including coroutines.
            */
            public StopCoroutine ($routine: System.Collections.IEnumerator) : void
            /** Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.
            * @param $methodName Name of coroutine.
            * @param $routine Name of the function in code, including coroutines.
            */
            public StopCoroutine ($routine: UnityEngine.Coroutine) : void
            /** Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.
            * @param $methodName Name of coroutine.
            * @param $routine Name of the function in code, including coroutines.
            */
            public StopCoroutine ($methodName: string) : void
            /** Stops all coroutines running on this behaviour.
            */
            public StopAllCoroutines () : void
            /** Logs message to the Unity Console (identical to Debug.Log).
            */
            public static print ($message: any) : void
            public constructor ()
        }
        /** MonoBehaviour.StartCoroutine returns a Coroutine. Instances of this class are only used to reference these coroutines, and do not hold any exposed properties or functions.
        */
        class Coroutine extends UnityEngine.YieldInstruction
        {
            protected [__keep_incompatibility]: never;
        }
        /** Type of the imported(native) data.
        */
        enum AudioType
        { UNKNOWN = 0, ACC = 1, AIFF = 2, IT = 10, MOD = 12, MPEG = 13, OGGVORBIS = 14, S3M = 17, WAV = 20, XM = 21, XMA = 22, VAG = 23, AUDIOQUEUE = 24 }
        /** Represents  a 128-bit hash value.
        */
        class Hash128 extends System.ValueType implements System.IComparable, System.IComparable$1<UnityEngine.Hash128>, System.IEquatable$1<UnityEngine.Hash128>
        {
            protected [__keep_incompatibility]: never;
        }
        /** Data structure for downloading AssetBundles to a customized cache path. Additional resources:UnityWebRequestAssetBundle.GetAssetBundle for more information.
        */
        class CachedAssetBundle extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        /** Helper class to generate form data to post to web servers using the UnityWebRequest or WWW classes.
        */
        class WWWForm extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICanvasRaycastFilter
        {
        }
        interface ISerializationCallbackReceiver
        {
        }
        /** Interface to control the Mecanim animation system.
        */
        class Animator extends UnityEngine.Behaviour
        {
            protected [__keep_incompatibility]: never;
        }
        /** Interface for on-screen keyboards. Only native iPhone, Android, and Windows Store Apps are supported.
        */
        class TouchScreenKeyboard extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        /** Enumeration of the different types of supported touchscreen keyboards.
        */
        enum TouchScreenKeyboardType
        { Default = 0, ASCIICapable = 1, NumbersAndPunctuation = 2, URL = 3, NumberPad = 4, PhonePad = 5, NamePhonePad = 6, EmailAddress = 7, NintendoNetworkAccount = 8, Social = 9, Search = 10, DecimalPad = 11, OneTimeCode = 12 }
        /** A UnityGUI event.
        */
        class Event extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class AudioBehaviour extends UnityEngine.Behaviour
        {
            protected [__keep_incompatibility]: never;
        }
        /** A representation of audio sources in 3D.
        */
        class AudioSource extends UnityEngine.AudioBehaviour
        {
            protected [__keep_incompatibility]: never;
        }
        /** A container for audio data.
        */
        class AudioClip extends UnityEngine.Audio.AudioResource
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Collections.Generic {
        interface IEnumerable$1<T> extends System.Collections.IEnumerable
        {
        }
        interface IReadOnlyList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<T>
        {
        }
        interface IReadOnlyCollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
        {
        }
        interface IList$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.ICollection$1<T>
        {
        }
        interface ICollection$1<T> extends System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
        {
        }
        class List$1<T> extends System.Object implements System.Collections.Generic.IReadOnlyList$1<T>, System.Collections.ICollection, System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IList$1<T>, System.Collections.Generic.IReadOnlyCollection$1<T>, System.Collections.IList, System.Collections.Generic.ICollection$1<T>
        {
            protected [__keep_incompatibility]: never;
            public get Capacity(): number;
            public set Capacity(value: number);
            public get Count(): number;
            public get_Item ($index: number) : T
            public set_Item ($index: number, $value: T) : void
            public Add ($item: T) : void
            public AddRange ($collection: System.Collections.Generic.IEnumerable$1<T>) : void
            public AsReadOnly () : System.Collections.ObjectModel.ReadOnlyCollection$1<T>
            public BinarySearch ($index: number, $count: number, $item: T, $comparer: System.Collections.Generic.IComparer$1<T>) : number
            public BinarySearch ($item: T) : number
            public BinarySearch ($item: T, $comparer: System.Collections.Generic.IComparer$1<T>) : number
            public Clear () : void
            public Contains ($item: T) : boolean
            public CopyTo ($array: System.Array$1<T>) : void
            public CopyTo ($index: number, $array: System.Array$1<T>, $arrayIndex: number, $count: number) : void
            public CopyTo ($array: System.Array$1<T>, $arrayIndex: number) : void
            public Exists ($match: System.Predicate$1<T>) : boolean
            public Find ($match: System.Predicate$1<T>) : T
            public FindAll ($match: System.Predicate$1<T>) : System.Collections.Generic.List$1<T>
            public FindIndex ($match: System.Predicate$1<T>) : number
            public FindIndex ($startIndex: number, $match: System.Predicate$1<T>) : number
            public FindIndex ($startIndex: number, $count: number, $match: System.Predicate$1<T>) : number
            public FindLast ($match: System.Predicate$1<T>) : T
            public FindLastIndex ($match: System.Predicate$1<T>) : number
            public FindLastIndex ($startIndex: number, $match: System.Predicate$1<T>) : number
            public FindLastIndex ($startIndex: number, $count: number, $match: System.Predicate$1<T>) : number
            public ForEach ($action: System.Action$1<T>) : void
            public GetEnumerator () : System.Collections.Generic.List$1.Enumerator<T>
            public GetRange ($index: number, $count: number) : System.Collections.Generic.List$1<T>
            public IndexOf ($item: T) : number
            public IndexOf ($item: T, $index: number) : number
            public IndexOf ($item: T, $index: number, $count: number) : number
            public Insert ($index: number, $item: T) : void
            public InsertRange ($index: number, $collection: System.Collections.Generic.IEnumerable$1<T>) : void
            public LastIndexOf ($item: T) : number
            public LastIndexOf ($item: T, $index: number) : number
            public LastIndexOf ($item: T, $index: number, $count: number) : number
            public Remove ($item: T) : boolean
            public RemoveAll ($match: System.Predicate$1<T>) : number
            public RemoveAt ($index: number) : void
            public RemoveRange ($index: number, $count: number) : void
            public Reverse () : void
            public Reverse ($index: number, $count: number) : void
            public Sort () : void
            public Sort ($comparer: System.Collections.Generic.IComparer$1<T>) : void
            public Sort ($index: number, $count: number, $comparer: System.Collections.Generic.IComparer$1<T>) : void
            public Sort ($comparison: System.Comparison$1<T>) : void
            public ToArray () : System.Array$1<T>
            public TrimExcess () : void
            public TrueForAll ($match: System.Predicate$1<T>) : boolean
            public constructor ()
            public constructor ($capacity: number)
            public constructor ($collection: System.Collections.Generic.IEnumerable$1<T>)
            public [Symbol.iterator]() : IterableIterator<T>
        }
        interface IComparer$1<T>
        {
        }
        interface IEnumerator$1<T> extends System.Collections.IEnumerator, System.IDisposable
        {
        }
        class Dictionary$2<TKey, TValue> extends System.Object implements System.Runtime.Serialization.IDeserializationCallback, System.Collections.Generic.IReadOnlyDictionary$2<TKey, TValue>, System.Collections.Generic.IDictionary$2<TKey, TValue>, System.Runtime.Serialization.ISerializable, System.Collections.ICollection, System.Collections.IDictionary, System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.Generic.ICollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        {
            protected [__keep_incompatibility]: never;
            public get Comparer(): System.Collections.Generic.IEqualityComparer$1<TKey>;
            public get Count(): number;
            public get Keys(): System.Collections.Generic.Dictionary$2.KeyCollection<TKey, TValue>;
            public get Values(): System.Collections.Generic.Dictionary$2.ValueCollection<TKey, TValue>;
            public get_Item ($key: TKey) : TValue
            public set_Item ($key: TKey, $value: TValue) : void
            public Add ($key: TKey, $value: TValue) : void
            public Clear () : void
            public ContainsKey ($key: TKey) : boolean
            public ContainsValue ($value: TValue) : boolean
            public GetEnumerator () : System.Collections.Generic.Dictionary$2.Enumerator<TKey, TValue>
            public GetObjectData ($info: System.Runtime.Serialization.SerializationInfo, $context: System.Runtime.Serialization.StreamingContext) : void
            public OnDeserialization ($sender: any) : void
            public Remove ($key: TKey) : boolean
            public TryGetValue ($key: TKey, $value: $Ref<TValue>) : boolean
            public EnsureCapacity ($capacity: number) : number
            public TrimExcess () : void
            public TrimExcess ($capacity: number) : void
            public constructor ()
            public constructor ($capacity: number)
            public constructor ($comparer: System.Collections.Generic.IEqualityComparer$1<TKey>)
            public constructor ($capacity: number, $comparer: System.Collections.Generic.IEqualityComparer$1<TKey>)
            public constructor ($dictionary: System.Collections.Generic.IDictionary$2<TKey, TValue>)
            public constructor ($dictionary: System.Collections.Generic.IDictionary$2<TKey, TValue>, $comparer: System.Collections.Generic.IEqualityComparer$1<TKey>)
            public constructor ($collection: System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>)
            public constructor ($collection: System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, $comparer: System.Collections.Generic.IEqualityComparer$1<TKey>)
            public [Symbol.iterator]() : IterableIterator<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        }
        interface IReadOnlyDictionary$2<TKey, TValue> extends System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        {
        }
        class KeyValuePair$2<TKey, TValue> extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        interface IDictionary$2<TKey, TValue> extends System.Collections.Generic.IEnumerable$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.Generic.ICollection$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>
        {
        }
        interface IEqualityComparer$1<T>
        {
        }
    }
    namespace System.Collections {
        interface IEnumerable
        {
        }
        interface IStructuralComparable
        {
        }
        interface IStructuralEquatable
        {
        }
        interface ICollection extends System.Collections.IEnumerable
        {
        }
        interface IList extends System.Collections.ICollection, System.Collections.IEnumerable
        {
        }
        interface IEnumerator
        {
        }
        interface IDictionary extends System.Collections.ICollection, System.Collections.IEnumerable
        {
        }
        interface IDictionaryEnumerator extends System.Collections.IEnumerator
        {
        }
    }
    namespace System.Runtime.Serialization {
        interface ISerializable
        {
        }
        interface IDeserializationCallback
        {
        }
        class SerializationInfo extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class StreamingContext extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.Application {
        interface AdvertisingIdentifierCallback
        { 
        (advertisingId: string, trackingEnabled: boolean, errorMsg: string) : void; 
        Invoke?: (advertisingId: string, trackingEnabled: boolean, errorMsg: string) => void;
        }
        var AdvertisingIdentifierCallback: { new (func: (advertisingId: string, trackingEnabled: boolean, errorMsg: string) => void): AdvertisingIdentifierCallback; }
        interface LowMemoryCallback
        { 
        () : void; 
        Invoke?: () => void;
        }
        var LowMemoryCallback: { new (func: () => void): LowMemoryCallback; }
        interface MemoryUsageChangedCallback
        { 
        (usage: $Ref<UnityEngine.ApplicationMemoryUsageChange>) : void; 
        Invoke?: (usage: $Ref<UnityEngine.ApplicationMemoryUsageChange>) => void;
        }
        var MemoryUsageChangedCallback: { new (func: (usage: $Ref<UnityEngine.ApplicationMemoryUsageChange>) => void): MemoryUsageChangedCallback; }
        interface LogCallback
        { 
        (condition: string, stackTrace: string, type: UnityEngine.LogType) : void; 
        Invoke?: (condition: string, stackTrace: string, type: UnityEngine.LogType) => void;
        }
        var LogCallback: { new (func: (condition: string, stackTrace: string, type: UnityEngine.LogType) => void): LogCallback; }
    }
    namespace UnityEngine.Events {
        /** Zero argument delegate used by UnityEvents.
        */
        interface UnityAction
        { 
        () : void; 
        Invoke?: () => void;
        }
        var UnityAction: { new (func: () => void): UnityAction; }
        /** Abstract base class for UnityEvents.
        */
        class UnityEventBase extends System.Object implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
        }
        /** A zero argument persistent callback that can be saved with the Scene.
        */
        class UnityEvent extends UnityEngine.Events.UnityEventBase implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
            /** Adds a non-persistent listener to the UnityEvent.
            * @param $call Callback function.
            */
            public AddListener ($call: UnityEngine.Events.UnityAction) : void
            /** Remove a non persistent listener from the UnityEvent. If you have added the same listener multiple times, this method will remove all occurrences of it.
            * @param $call Callback function.
            */
            public RemoveListener ($call: UnityEngine.Events.UnityAction) : void
            /** Invoke all registered callbacks (runtime and persistent).
            */
            public Invoke () : void
            public constructor ()
        }
        class UnityEvent$1<T0> extends UnityEngine.Events.UnityEventBase implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
            public AddListener ($call: UnityEngine.Events.UnityAction$1<T0>) : void
            public RemoveListener ($call: UnityEngine.Events.UnityAction$1<T0>) : void
            public Invoke ($arg0: T0) : void
            public constructor ()
        }
        interface UnityAction$1<T0>
        { 
        (arg0: T0) : void; 
        Invoke?: (arg0: T0) => void;
        }
    }
    namespace System.Threading {
        class CancellationToken extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        interface IThreadPoolWorkItem
        {
        }
    }
    namespace System.Runtime.InteropServices {
        interface _Exception
        {
        }
        interface _MemberInfo
        {
        }
        interface _Type
        {
        }
        interface _MethodBase
        {
        }
        interface _MethodInfo
        {
        }
        interface _Assembly
        {
        }
        interface _Module
        {
        }
        interface _Attribute
        {
        }
        class StructLayoutAttribute extends System.Attribute implements System.Runtime.InteropServices._Attribute
        {
            protected [__keep_incompatibility]: never;
        }
        interface _ConstructorInfo
        {
        }
        interface _EventInfo
        {
        }
        interface _FieldInfo
        {
        }
        interface _PropertyInfo
        {
        }
        interface _AssemblyName
        {
        }
    }
    namespace UnityEngine.Debug {
        class StartupLog extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Collections.ObjectModel {
        class ReadOnlyCollection$1<T> extends System.Object implements System.Collections.Generic.IReadOnlyList$1<T>, System.Collections.ICollection, System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.Collections.Generic.IList$1<T>, System.Collections.Generic.IReadOnlyCollection$1<T>, System.Collections.IList, System.Collections.Generic.ICollection$1<T>
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<T>
        }
    }
    namespace System.Collections.Generic.List$1 {
        class Enumerator<T> extends System.ValueType implements System.Collections.Generic.IEnumerator$1<T>, System.Collections.IEnumerator, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Collections.Generic.Dictionary$2 {
        class KeyCollection<TKey, TValue> extends System.Object implements System.Collections.ICollection, System.Collections.Generic.IEnumerable$1<TKey>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<TKey>, System.Collections.Generic.ICollection$1<TKey>
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<TKey>
        }
        class ValueCollection<TKey, TValue> extends System.Object implements System.Collections.ICollection, System.Collections.Generic.IEnumerable$1<TValue>, System.Collections.IEnumerable, System.Collections.Generic.IReadOnlyCollection$1<TValue>, System.Collections.Generic.ICollection$1<TValue>
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<TValue>
        }
        class Enumerator<TKey, TValue> extends System.ValueType implements System.Collections.IDictionaryEnumerator, System.Collections.Generic.IEnumerator$1<System.Collections.Generic.KeyValuePair$2<TKey, TValue>>, System.Collections.IEnumerator, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace Unity.IntegerTime {
        /** Data type that represents time as an integer count of a rational number.
        */
        class RationalTime extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Reflection {
        class MemberInfo extends System.Object implements System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICustomAttributeProvider
        {
        }
        interface IReflect
        {
        }
        class MethodBase extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._MethodBase, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        class MethodInfo extends System.Reflection.MethodBase implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._MethodBase, System.Runtime.InteropServices._MethodInfo, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        interface MemberFilter
        { 
        (m: System.Reflection.MemberInfo, filterCriteria: any) : boolean; 
        Invoke?: (m: System.Reflection.MemberInfo, filterCriteria: any) => boolean;
        }
        var MemberFilter: { new (func: (m: System.Reflection.MemberInfo, filterCriteria: any) => boolean): MemberFilter; }
        interface TypeFilter
        { 
        (m: System.Type, filterCriteria: any) : boolean; 
        Invoke?: (m: System.Type, filterCriteria: any) => boolean;
        }
        var TypeFilter: { new (func: (m: System.Type, filterCriteria: any) => boolean): TypeFilter; }
        enum MemberTypes
        { Constructor = 1, Event = 2, Field = 4, Method = 8, Property = 16, TypeInfo = 32, Custom = 64, NestedType = 128, All = 191 }
        enum BindingFlags
        { Default = 0, IgnoreCase = 1, DeclaredOnly = 2, Instance = 4, Static = 8, Public = 16, NonPublic = 32, FlattenHierarchy = 64, InvokeMethod = 256, CreateInstance = 512, GetField = 1024, SetField = 2048, GetProperty = 4096, SetProperty = 8192, PutDispProperty = 16384, PutRefDispProperty = 32768, ExactBinding = 65536, SuppressChangeType = 131072, OptionalParamBinding = 262144, IgnoreReturn = 16777216, DoNotWrapExceptions = 33554432 }
        class Assembly extends System.Object implements System.Runtime.Serialization.ISerializable, System.Reflection.ICustomAttributeProvider, System.Security.IEvidenceFactory, System.Runtime.InteropServices._Assembly
        {
            protected [__keep_incompatibility]: never;
        }
        class Module extends System.Object implements System.Runtime.Serialization.ISerializable, System.Runtime.InteropServices._Module, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        enum GenericParameterAttributes
        { None = 0, VarianceMask = 3, Covariant = 1, Contravariant = 2, SpecialConstraintMask = 28, ReferenceTypeConstraint = 4, NotNullableValueTypeConstraint = 8, DefaultConstructorConstraint = 16 }
        enum TypeAttributes
        { VisibilityMask = 7, NotPublic = 0, Public = 1, NestedPublic = 2, NestedPrivate = 3, NestedFamily = 4, NestedAssembly = 5, NestedFamANDAssem = 6, NestedFamORAssem = 7, LayoutMask = 24, AutoLayout = 0, SequentialLayout = 8, ExplicitLayout = 16, ClassSemanticsMask = 32, Class = 0, Interface = 32, Abstract = 128, Sealed = 256, SpecialName = 1024, Import = 4096, Serializable = 8192, WindowsRuntime = 16384, StringFormatMask = 196608, AnsiClass = 0, UnicodeClass = 65536, AutoClass = 131072, CustomFormatClass = 196608, CustomFormatMask = 12582912, BeforeFieldInit = 1048576, RTSpecialName = 2048, HasSecurity = 262144, ReservedMask = 264192 }
        class ConstructorInfo extends System.Reflection.MethodBase implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._MethodBase, System.Runtime.InteropServices._ConstructorInfo, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        class Binder extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class ParameterModifier extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        enum CallingConventions
        { Standard = 1, VarArgs = 2, Any = 3, HasThis = 32, ExplicitThis = 64 }
        class EventInfo extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Runtime.InteropServices._EventInfo, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        class FieldInfo extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider, System.Runtime.InteropServices._FieldInfo
        {
            protected [__keep_incompatibility]: never;
        }
        class PropertyInfo extends System.Reflection.MemberInfo implements System.Runtime.InteropServices._PropertyInfo, System.Runtime.InteropServices._MemberInfo, System.Reflection.ICustomAttributeProvider
        {
            protected [__keep_incompatibility]: never;
        }
        class InterfaceMapping extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class AssemblyName extends System.Object implements System.Runtime.InteropServices._AssemblyName, System.Runtime.Serialization.IDeserializationCallback, System.Runtime.Serialization.ISerializable, System.ICloneable
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace Unity.Collections {
        class NativeArray$1<T> extends System.ValueType implements System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable, System.IDisposable, System.IEquatable$1<Unity.Collections.NativeArray$1<T>>
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<T>
        }
    }
    namespace UnityEngine.SceneManagement {
        /** Run-time data structure for *.unity file.
        */
        class Scene extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Security {
        interface IEvidenceFactory
        {
        }
    }
    namespace System.Globalization {
        class CultureInfo extends System.Object implements System.ICloneable, System.IFormatProvider
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.ParticleSystem {
        class Particle extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class PlaybackState extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class Trails extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class EmitParams extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class MainModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class EmissionModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class ShapeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class VelocityOverLifetimeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class LimitVelocityOverLifetimeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class InheritVelocityModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class LifetimeByEmitterSpeedModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class ForceOverLifetimeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class ColorOverLifetimeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class ColorBySpeedModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class SizeOverLifetimeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class SizeBySpeedModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class RotationOverLifetimeModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class RotationBySpeedModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class ExternalForcesModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class NoiseModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class CollisionModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class TriggerModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class SubEmittersModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class TextureSheetAnimationModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class LightsModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class TrailModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class CustomDataModule extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.Canvas {
        interface WillRenderCanvases
        { 
        () : void; 
        Invoke?: () => void;
        }
        var WillRenderCanvases: { new (func: () => void): WillRenderCanvases; }
    }
    namespace System.IO {
        class File extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static OpenText ($path: string) : System.IO.StreamReader
            public static CreateText ($path: string) : System.IO.StreamWriter
            public static AppendText ($path: string) : System.IO.StreamWriter
            public static Copy ($sourceFileName: string, $destFileName: string) : void
            public static Copy ($sourceFileName: string, $destFileName: string, $overwrite: boolean) : void
            public static Create ($path: string) : System.IO.FileStream
            public static Create ($path: string, $bufferSize: number) : System.IO.FileStream
            public static Create ($path: string, $bufferSize: number, $options: System.IO.FileOptions) : System.IO.FileStream
            public static Delete ($path: string) : void
            public static Exists ($path: string) : boolean
            public static Open ($path: string, $mode: System.IO.FileMode) : System.IO.FileStream
            public static Open ($path: string, $mode: System.IO.FileMode, $access: System.IO.FileAccess) : System.IO.FileStream
            public static Open ($path: string, $mode: System.IO.FileMode, $access: System.IO.FileAccess, $share: System.IO.FileShare) : System.IO.FileStream
            public static SetCreationTime ($path: string, $creationTime: System.DateTime) : void
            public static SetCreationTimeUtc ($path: string, $creationTimeUtc: System.DateTime) : void
            public static GetCreationTime ($path: string) : System.DateTime
            public static GetCreationTimeUtc ($path: string) : System.DateTime
            public static SetLastAccessTime ($path: string, $lastAccessTime: System.DateTime) : void
            public static SetLastAccessTimeUtc ($path: string, $lastAccessTimeUtc: System.DateTime) : void
            public static GetLastAccessTime ($path: string) : System.DateTime
            public static GetLastAccessTimeUtc ($path: string) : System.DateTime
            public static SetLastWriteTime ($path: string, $lastWriteTime: System.DateTime) : void
            public static SetLastWriteTimeUtc ($path: string, $lastWriteTimeUtc: System.DateTime) : void
            public static GetLastWriteTime ($path: string) : System.DateTime
            public static GetLastWriteTimeUtc ($path: string) : System.DateTime
            public static GetAttributes ($path: string) : System.IO.FileAttributes
            public static SetAttributes ($path: string, $fileAttributes: System.IO.FileAttributes) : void
            public static OpenRead ($path: string) : System.IO.FileStream
            public static OpenWrite ($path: string) : System.IO.FileStream
            public static ReadAllText ($path: string) : string
            public static ReadAllText ($path: string, $encoding: System.Text.Encoding) : string
            public static WriteAllText ($path: string, $contents: string) : void
            public static WriteAllText ($path: string, $contents: string, $encoding: System.Text.Encoding) : void
            public static ReadAllBytes ($path: string) : System.Array$1<number>
            public static WriteAllBytes ($path: string, $bytes: System.Array$1<number>) : void
            public static ReadAllLines ($path: string) : System.Array$1<string>
            public static ReadAllLines ($path: string, $encoding: System.Text.Encoding) : System.Array$1<string>
            public static ReadLines ($path: string) : System.Collections.Generic.IEnumerable$1<string>
            public static ReadLines ($path: string, $encoding: System.Text.Encoding) : System.Collections.Generic.IEnumerable$1<string>
            public static WriteAllLines ($path: string, $contents: System.Array$1<string>) : void
            public static WriteAllLines ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>) : void
            public static WriteAllLines ($path: string, $contents: System.Array$1<string>, $encoding: System.Text.Encoding) : void
            public static WriteAllLines ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>, $encoding: System.Text.Encoding) : void
            public static AppendAllText ($path: string, $contents: string) : void
            public static AppendAllText ($path: string, $contents: string, $encoding: System.Text.Encoding) : void
            public static AppendAllLines ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>) : void
            public static AppendAllLines ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>, $encoding: System.Text.Encoding) : void
            public static Replace ($sourceFileName: string, $destinationFileName: string, $destinationBackupFileName: string) : void
            public static Replace ($sourceFileName: string, $destinationFileName: string, $destinationBackupFileName: string, $ignoreMetadataErrors: boolean) : void
            public static Move ($sourceFileName: string, $destFileName: string) : void
            public static Encrypt ($path: string) : void
            public static Decrypt ($path: string) : void
            public static ReadAllTextAsync ($path: string, $cancellationToken?: System.Threading.CancellationToken) : System.Threading.Tasks.Task$1<string>
            public static ReadAllTextAsync ($path: string, $encoding: System.Text.Encoding, $cancellationToken?: System.Threading.CancellationToken) : System.Threading.Tasks.Task$1<string>
            public static WriteAllTextAsync ($path: string, $contents: string, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static WriteAllTextAsync ($path: string, $contents: string, $encoding: System.Text.Encoding, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static ReadAllBytesAsync ($path: string, $cancellationToken?: System.Threading.CancellationToken) : System.Threading.Tasks.Task$1<System.Array$1<number>>
            public static WriteAllBytesAsync ($path: string, $bytes: System.Array$1<number>, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static ReadAllLinesAsync ($path: string, $cancellationToken?: System.Threading.CancellationToken) : System.Threading.Tasks.Task$1<System.Array$1<string>>
            public static ReadAllLinesAsync ($path: string, $encoding: System.Text.Encoding, $cancellationToken?: System.Threading.CancellationToken) : System.Threading.Tasks.Task$1<System.Array$1<string>>
            public static WriteAllLinesAsync ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static WriteAllLinesAsync ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>, $encoding: System.Text.Encoding, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static AppendAllTextAsync ($path: string, $contents: string, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static AppendAllTextAsync ($path: string, $contents: string, $encoding: System.Text.Encoding, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static AppendAllLinesAsync ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static AppendAllLinesAsync ($path: string, $contents: System.Collections.Generic.IEnumerable$1<string>, $encoding: System.Text.Encoding, $cancellationToken?: System.Threading.CancellationToken) : $Task<any>
            public static Create ($path: string, $bufferSize: number, $options: System.IO.FileOptions, $fileSecurity: System.Security.AccessControl.FileSecurity) : System.IO.FileStream
            public static GetAccessControl ($path: string) : System.Security.AccessControl.FileSecurity
            public static GetAccessControl ($path: string, $includeSections: System.Security.AccessControl.AccessControlSections) : System.Security.AccessControl.FileSecurity
            public static SetAccessControl ($path: string, $fileSecurity: System.Security.AccessControl.FileSecurity) : void
        }
        class TextReader extends System.MarshalByRefObject implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class StreamReader extends System.IO.TextReader implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class TextWriter extends System.MarshalByRefObject implements System.IAsyncDisposable, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class StreamWriter extends System.IO.TextWriter implements System.IAsyncDisposable, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class Stream extends System.MarshalByRefObject implements System.IAsyncDisposable, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class FileStream extends System.IO.Stream implements System.IAsyncDisposable, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        enum FileOptions
        { None = 0, WriteThrough = -2147483648, Asynchronous = 1073741824, RandomAccess = 268435456, DeleteOnClose = 67108864, SequentialScan = 134217728, Encrypted = 16384 }
        enum FileMode
        { CreateNew = 1, Create = 2, Open = 3, OpenOrCreate = 4, Truncate = 5, Append = 6 }
        enum FileAccess
        { Read = 1, Write = 2, ReadWrite = 3 }
        enum FileShare
        { None = 0, Read = 1, Write = 2, ReadWrite = 3, Delete = 4, Inheritable = 16 }
        enum FileAttributes
        { ReadOnly = 1, Hidden = 2, System = 4, Directory = 16, Archive = 32, Device = 64, Normal = 128, Temporary = 256, SparseFile = 512, ReparsePoint = 1024, Compressed = 2048, Offline = 4096, NotContentIndexed = 8192, Encrypted = 16384, IntegrityStream = 32768, NoScrubData = 131072 }
        class Path extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static AltDirectorySeparatorChar : number
            public static DirectorySeparatorChar : number
            public static PathSeparator : number
            public static VolumeSeparatorChar : number
            public static ChangeExtension ($path: string, $extension: string) : string
            public static Combine ($path1: string, $path2: string) : string
            public static GetDirectoryName ($path: string) : string
            public static GetExtension ($path: string) : string
            public static GetFileName ($path: string) : string
            public static GetFileNameWithoutExtension ($path: string) : string
            public static GetFullPath ($path: string) : string
            public static GetPathRoot ($path: string) : string
            public static GetTempFileName () : string
            public static GetTempPath () : string
            public static HasExtension ($path: string) : boolean
            public static IsPathRooted ($path: string) : boolean
            public static GetInvalidFileNameChars () : System.Array$1<number>
            public static GetInvalidPathChars () : System.Array$1<number>
            public static GetRandomFileName () : string
            public static Combine (...paths: string[]) : string
            public static Combine ($path1: string, $path2: string, $path3: string) : string
            public static Combine ($path1: string, $path2: string, $path3: string, $path4: string) : string
            public static GetRelativePath ($relativeTo: string, $path: string) : string
            public static IsPathFullyQualified ($path: string) : boolean
            public static GetFullPath ($path: string, $basePath: string) : string
        }
        class Directory extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static GetParent ($path: string) : System.IO.DirectoryInfo
            public static CreateDirectory ($path: string) : System.IO.DirectoryInfo
            public static Exists ($path: string) : boolean
            public static SetCreationTime ($path: string, $creationTime: System.DateTime) : void
            public static SetCreationTimeUtc ($path: string, $creationTimeUtc: System.DateTime) : void
            public static GetCreationTime ($path: string) : System.DateTime
            public static GetCreationTimeUtc ($path: string) : System.DateTime
            public static SetLastWriteTime ($path: string, $lastWriteTime: System.DateTime) : void
            public static SetLastWriteTimeUtc ($path: string, $lastWriteTimeUtc: System.DateTime) : void
            public static GetLastWriteTime ($path: string) : System.DateTime
            public static GetLastWriteTimeUtc ($path: string) : System.DateTime
            public static SetLastAccessTime ($path: string, $lastAccessTime: System.DateTime) : void
            public static SetLastAccessTimeUtc ($path: string, $lastAccessTimeUtc: System.DateTime) : void
            public static GetLastAccessTime ($path: string) : System.DateTime
            public static GetLastAccessTimeUtc ($path: string) : System.DateTime
            public static GetFiles ($path: string) : System.Array$1<string>
            public static GetFiles ($path: string, $searchPattern: string) : System.Array$1<string>
            public static GetFiles ($path: string, $searchPattern: string, $searchOption: System.IO.SearchOption) : System.Array$1<string>
            public static GetFiles ($path: string, $searchPattern: string, $enumerationOptions: System.IO.EnumerationOptions) : System.Array$1<string>
            public static GetDirectories ($path: string) : System.Array$1<string>
            public static GetDirectories ($path: string, $searchPattern: string) : System.Array$1<string>
            public static GetDirectories ($path: string, $searchPattern: string, $searchOption: System.IO.SearchOption) : System.Array$1<string>
            public static GetDirectories ($path: string, $searchPattern: string, $enumerationOptions: System.IO.EnumerationOptions) : System.Array$1<string>
            public static GetFileSystemEntries ($path: string) : System.Array$1<string>
            public static GetFileSystemEntries ($path: string, $searchPattern: string) : System.Array$1<string>
            public static GetFileSystemEntries ($path: string, $searchPattern: string, $searchOption: System.IO.SearchOption) : System.Array$1<string>
            public static GetFileSystemEntries ($path: string, $searchPattern: string, $enumerationOptions: System.IO.EnumerationOptions) : System.Array$1<string>
            public static EnumerateDirectories ($path: string) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateDirectories ($path: string, $searchPattern: string) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateDirectories ($path: string, $searchPattern: string, $searchOption: System.IO.SearchOption) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateDirectories ($path: string, $searchPattern: string, $enumerationOptions: System.IO.EnumerationOptions) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFiles ($path: string) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFiles ($path: string, $searchPattern: string) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFiles ($path: string, $searchPattern: string, $searchOption: System.IO.SearchOption) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFiles ($path: string, $searchPattern: string, $enumerationOptions: System.IO.EnumerationOptions) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFileSystemEntries ($path: string) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFileSystemEntries ($path: string, $searchPattern: string) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFileSystemEntries ($path: string, $searchPattern: string, $searchOption: System.IO.SearchOption) : System.Collections.Generic.IEnumerable$1<string>
            public static EnumerateFileSystemEntries ($path: string, $searchPattern: string, $enumerationOptions: System.IO.EnumerationOptions) : System.Collections.Generic.IEnumerable$1<string>
            public static GetDirectoryRoot ($path: string) : string
            public static GetCurrentDirectory () : string
            public static SetCurrentDirectory ($path: string) : void
            public static Move ($sourceDirName: string, $destDirName: string) : void
            public static Delete ($path: string) : void
            public static Delete ($path: string, $recursive: boolean) : void
            public static GetLogicalDrives () : System.Array$1<string>
            public static CreateDirectory ($path: string, $directorySecurity: System.Security.AccessControl.DirectorySecurity) : System.IO.DirectoryInfo
            public static GetAccessControl ($path: string, $includeSections: System.Security.AccessControl.AccessControlSections) : System.Security.AccessControl.DirectorySecurity
            public static GetAccessControl ($path: string) : System.Security.AccessControl.DirectorySecurity
            public static SetAccessControl ($path: string, $directorySecurity: System.Security.AccessControl.DirectorySecurity) : void
        }
        class FileSystemInfo extends System.MarshalByRefObject implements System.Runtime.Serialization.ISerializable
        {
            protected [__keep_incompatibility]: never;
        }
        class DirectoryInfo extends System.IO.FileSystemInfo implements System.Runtime.Serialization.ISerializable
        {
            protected [__keep_incompatibility]: never;
        }
        enum SearchOption
        { TopDirectoryOnly = 0, AllDirectories = 1 }
        class EnumerationOptions extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Text {
        class Encoding extends System.Object implements System.ICloneable
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Threading.Tasks {
        class Task extends System.Object implements System.IAsyncResult, System.Threading.IThreadPoolWorkItem, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class Task$1<TResult> extends System.Threading.Tasks.Task implements System.IAsyncResult, System.Threading.IThreadPoolWorkItem, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace System.Security.AccessControl {
        class ObjectSecurity extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class CommonObjectSecurity extends System.Security.AccessControl.ObjectSecurity
        {
            protected [__keep_incompatibility]: never;
        }
        class NativeObjectSecurity extends System.Security.AccessControl.CommonObjectSecurity
        {
            protected [__keep_incompatibility]: never;
        }
        class FileSystemSecurity extends System.Security.AccessControl.NativeObjectSecurity
        {
            protected [__keep_incompatibility]: never;
        }
        class FileSecurity extends System.Security.AccessControl.FileSystemSecurity
        {
            protected [__keep_incompatibility]: never;
        }
        enum AccessControlSections
        { None = 0, Audit = 1, Access = 2, Owner = 4, Group = 8, All = 15 }
        class DirectorySecurity extends System.Security.AccessControl.FileSystemSecurity
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.Networking {
        /** Provides methods to communicate with web servers.
        */
        class UnityWebRequest extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
            /** The string "GET", commonly used as the verb for an HTTP GET request.
            */
            public static kHttpVerbGET : string
            /** The string "HEAD", commonly used as the verb for an HTTP HEAD request.
            */
            public static kHttpVerbHEAD : string
            /** The string "POST", commonly used as the verb for an HTTP POST request.
            */
            public static kHttpVerbPOST : string
            /** The string "PUT", commonly used as the verb for an HTTP PUT request.
            */
            public static kHttpVerbPUT : string
            /** The string "CREATE", commonly used as the verb for an HTTP CREATE request.
            */
            public static kHttpVerbCREATE : string
            /** The string "DELETE", commonly used as the verb for an HTTP DELETE request.
            */
            public static kHttpVerbDELETE : string
            /** If true, any CertificateHandler attached to this UnityWebRequest will have CertificateHandler.Dispose called automatically when UnityWebRequest.Dispose is called.
            */
            public get disposeCertificateHandlerOnDispose(): boolean;
            public set disposeCertificateHandlerOnDispose(value: boolean);
            /** If true, any DownloadHandler attached to this UnityWebRequest will have DownloadHandler.Dispose called automatically when UnityWebRequest.Dispose is called.
            */
            public get disposeDownloadHandlerOnDispose(): boolean;
            public set disposeDownloadHandlerOnDispose(value: boolean);
            /** If true, any UploadHandler attached to this UnityWebRequest will have UploadHandler.Dispose called automatically when UnityWebRequest.Dispose is called.
            */
            public get disposeUploadHandlerOnDispose(): boolean;
            public set disposeUploadHandlerOnDispose(value: boolean);
            /** Defines the HTTP verb used by this UnityWebRequest, such as GET or POST.
            */
            public get method(): string;
            public set method(value: string);
            /** A human-readable string describing any system errors encountered by this UnityWebRequest object while handling HTTP requests or responses. The default value is null. (Read Only)
            */
            public get error(): string;
            /** Determines whether this UnityWebRequest will include Expect: 100-Continue in its outgoing request headers. (Default: true).
            */
            public get useHttpContinue(): boolean;
            public set useHttpContinue(value: boolean);
            /** Defines the target URL for the UnityWebRequest to communicate with.
            */
            public get url(): string;
            public set url(value: string);
            /** Defines the target URI for the UnityWebRequest to communicate with.
            */
            public get uri(): System.Uri;
            public set uri(value: System.Uri);
            /** The numeric HTTP response code returned by the server, such as 200, 404 or 500. (Read Only)
            */
            public get responseCode(): bigint;
            /** Returns a floating-point value between 0.0 and 1.0, indicating the progress of uploading body data to the server.
            */
            public get uploadProgress(): number;
            /** Returns true while a UnityWebRequest’s configuration properties can be altered. (Read Only)
            */
            public get isModifiable(): boolean;
            /** Returns true after the UnityWebRequest has finished communicating with the remote server. (Read Only)
            */
            public get isDone(): boolean;
            /** The result of this UnityWebRequest.
            */
            public get result(): UnityEngine.Networking.UnityWebRequest.Result;
            /** Returns a floating-point value between 0.0 and 1.0, indicating the progress of downloading body data from the server. (Read Only)
            */
            public get downloadProgress(): number;
            /** Returns the number of bytes of body data the system has uploaded to the remote server. (Read Only)
            */
            public get uploadedBytes(): bigint;
            /** Returns the number of bytes of body data the system has downloaded from the remote server. (Read Only)
            */
            public get downloadedBytes(): bigint;
            /** Indicates the number of redirects that this UnityWebRequest follows before halting with a Redirect Limit Exceeded system error.
            */
            public get redirectLimit(): number;
            public set redirectLimit(value: number);
            /** Holds a reference to the UploadHandler object which manages body data to be uploaded to the remote server.
            */
            public get uploadHandler(): UnityEngine.Networking.UploadHandler;
            public set uploadHandler(value: UnityEngine.Networking.UploadHandler);
            /** Holds a reference to a DownloadHandler object, which manages body data received from the remote server by this UnityWebRequest.
            */
            public get downloadHandler(): UnityEngine.Networking.DownloadHandler;
            public set downloadHandler(value: UnityEngine.Networking.DownloadHandler);
            /** Holds a reference to a CertificateHandler object, which manages certificate validation for this UnityWebRequest.
            */
            public get certificateHandler(): UnityEngine.Networking.CertificateHandler;
            public set certificateHandler(value: UnityEngine.Networking.CertificateHandler);
            /** Sets UnityWebRequest to attempt to abort after the number of seconds in timeout have passed.
            */
            public get timeout(): number;
            public set timeout(value: number);
            /** Clears stored cookies from the cache.
            * @param $uri An optional URL to define which cookies are removed. Only cookies that apply to this URL are removed from the cache.
            */
            public static ClearCookieCache () : void
            /** Clears stored cookies from the cache.
            * @param $uri An optional URL to define which cookies are removed. Only cookies that apply to this URL are removed from the cache.
            */
            public static ClearCookieCache ($uri: System.Uri) : void
            /** Signals that this UnityWebRequest is no longer being used, and should clean up any resources it is using.
            */
            public Dispose () : void
            /** Begin communicating with the remote server.
            */
            public SendWebRequest () : UnityEngine.Networking.UnityWebRequestAsyncOperation
            /** If in progress, halts the UnityWebRequest as soon as possible.
            */
            public Abort () : void
            /** Retrieves the value of a custom request header.
            * @param $name Name of the custom request header. Case-insensitive.
            * @returns The value of the custom request header. If no custom header with a matching name has been set, returns an empty string. 
            */
            public GetRequestHeader ($name: string) : string
            /** Set a HTTP request header to a custom value.
            * @param $name The key of the header to be set. Case-sensitive.
            * @param $value The header's intended value.
            */
            public SetRequestHeader ($name: string, $value: string) : void
            /** Retrieves the value of a response header from the latest HTTP response received.
            * @param $name The name of the HTTP header to retrieve. Case-insensitive.
            * @returns The value of the HTTP header from the latest HTTP response. If no header with a matching name has been received, or no responses have been received, returns null. 
            */
            public GetResponseHeader ($name: string) : string
            /** Retrieves a dictionary containing all the response headers received by this UnityWebRequest in the latest HTTP response.
            * @returns A dictionary containing all the response headers received in the latest HTTP response. If no responses have been received, returns null. 
            */
            public GetResponseHeaders () : System.Collections.Generic.Dictionary$2<string, string>
            /** Create a UnityWebRequest for HTTP GET.
            * @param $uri The URI of the resource to retrieve via HTTP GET.
            * @returns An object that retrieves data from the uri. 
            */
            public static Get ($uri: string) : UnityEngine.Networking.UnityWebRequest
            /** Create a UnityWebRequest for HTTP GET.
            * @param $uri The URI of the resource to retrieve via HTTP GET.
            * @returns An object that retrieves data from the uri. 
            */
            public static Get ($uri: System.Uri) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured for HTTP DELETE.
            * @param $uri The URI to which a DELETE request should be sent.
            * @returns A UnityWebRequest configured to send an HTTP DELETE request. 
            */
            public static Delete ($uri: string) : UnityEngine.Networking.UnityWebRequest
            public static Delete ($uri: System.Uri) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send a HTTP HEAD request.
            * @param $uri The URI to which to send a HTTP HEAD request.
            * @returns A UnityWebRequest configured to transmit a HTTP HEAD request. 
            */
            public static Head ($uri: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send a HTTP HEAD request.
            * @param $uri The URI to which to send a HTTP HEAD request.
            * @returns A UnityWebRequest configured to transmit a HTTP HEAD request. 
            */
            public static Head ($uri: System.Uri) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to upload raw data to a remote server via HTTP PUT.
            * @param $uri The URI to which the data will be sent.
            * @param $bodyData The data to transmit to the remote server.
            If a string, the string will be converted to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
            * @returns A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT. 
            */
            public static Put ($uri: string, $bodyData: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to upload raw data to a remote server via HTTP PUT.
            * @param $uri The URI to which the data will be sent.
            * @param $bodyData The data to transmit to the remote server.
            If a string, the string will be converted to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
            * @returns A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT. 
            */
            public static Put ($uri: System.Uri, $bodyData: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to upload raw data to a remote server via HTTP PUT.
            * @param $uri The URI to which the data will be sent.
            * @param $bodyData The data to transmit to the remote server.
            If a string, the string will be converted to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
            * @returns A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT. 
            */
            public static Put ($uri: string, $bodyData: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to upload raw data to a remote server via HTTP PUT.
            * @param $uri The URI to which the data will be sent.
            * @param $bodyData The data to transmit to the remote server.
            If a string, the string will be converted to raw bytes via <a href="https:msdn.microsoft.comen-uslibrarysystem.text.encoding.utf8">System.Text.Encoding.UTF8<a>.
            * @returns A UnityWebRequest configured to transmit bodyData to uri via HTTP PUT. 
            */
            public static Put ($uri: System.Uri, $bodyData: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $form An HTML form to send.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static PostWwwForm ($uri: string, $form: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $form An HTML form to send.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static PostWwwForm ($uri: System.Uri, $form: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which the string will be transmitted.
            * @param $postData Form body data. Will be converted to UTF-8 string.
            * @param $contentType Value for the Content-Type header, for example application/json.
            * @returns A UnityWebRequest configured to send string to uri via POST. 
            */
            public static Post ($uri: string, $postData: string, $contentType: string) : UnityEngine.Networking.UnityWebRequest
            /** Creates a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which the string will be transmitted.
            * @param $postData Form body data. Will be converted to UTF-8 string.
            * @param $contentType Value for the Content-Type header, for example application/json.
            * @returns A UnityWebRequest configured to send string to uri via POST. 
            */
            public static Post ($uri: System.Uri, $postData: string, $contentType: string) : UnityEngine.Networking.UnityWebRequest
            /** Create a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $formData Form fields or files encapsulated in a WWWForm object, for formatting and transmission to the remote server.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static Post ($uri: string, $formData: UnityEngine.WWWForm) : UnityEngine.Networking.UnityWebRequest
            /** Create a UnityWebRequest configured to send form data to a server via HTTP POST.
            * @param $uri The target URI to which form data will be transmitted.
            * @param $formData Form fields or files encapsulated in a WWWForm object, for formatting and transmission to the remote server.
            * @returns A UnityWebRequest configured to send form data to uri via POST. 
            */
            public static Post ($uri: System.Uri, $formData: UnityEngine.WWWForm) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: string, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: System.Uri, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: string, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>, $boundary: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: System.Uri, $multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>, $boundary: System.Array$1<number>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: string, $formFields: System.Collections.Generic.Dictionary$2<string, string>) : UnityEngine.Networking.UnityWebRequest
            public static Post ($uri: System.Uri, $formFields: System.Collections.Generic.Dictionary$2<string, string>) : UnityEngine.Networking.UnityWebRequest
            /** Escapes characters in a string to ensure they are URL-friendly.
            * @param $s A string with characters to be escaped.
            * @param $e The text encoding to use.
            */
            public static EscapeURL ($s: string) : string
            /** Escapes characters in a string to ensure they are URL-friendly.
            * @param $s A string with characters to be escaped.
            * @param $e The text encoding to use.
            */
            public static EscapeURL ($s: string, $e: System.Text.Encoding) : string
            /** Converts URL-friendly escape sequences back to normal text.
            * @param $s A string containing escaped characters.
            * @param $e The text encoding to use.
            */
            public static UnEscapeURL ($s: string) : string
            /** Converts URL-friendly escape sequences back to normal text.
            * @param $s A string containing escaped characters.
            * @param $e The text encoding to use.
            */
            public static UnEscapeURL ($s: string, $e: System.Text.Encoding) : string
            public static SerializeFormSections ($multipartFormSections: System.Collections.Generic.List$1<UnityEngine.Networking.IMultipartFormSection>, $boundary: System.Array$1<number>) : System.Array$1<number>
            /** Generate a random 40-byte array for use as a multipart form boundary.
            * @returns 40 random bytes, guaranteed to contain only printable ASCII values. 
            */
            public static GenerateBoundary () : System.Array$1<number>
            public static SerializeSimpleForm ($formFields: System.Collections.Generic.Dictionary$2<string, string>) : System.Array$1<number>
            public constructor ()
            public constructor ($url: string)
            public constructor ($uri: System.Uri)
            public constructor ($url: string, $method: string)
            public constructor ($uri: System.Uri, $method: string)
            public constructor ($url: string, $method: string, $downloadHandler: UnityEngine.Networking.DownloadHandler, $uploadHandler: UnityEngine.Networking.UploadHandler)
            public constructor ($uri: System.Uri, $method: string, $downloadHandler: UnityEngine.Networking.DownloadHandler, $uploadHandler: UnityEngine.Networking.UploadHandler)
        }
        /** Asynchronous operation object returned from UnityWebRequest.SendWebRequest().
        You can yield until it continues, register an event handler with AsyncOperation.completed, or manually check whether it's done (AsyncOperation.isDone) or progress (AsyncOperation.progress).
        */
        class UnityWebRequestAsyncOperation extends UnityEngine.AsyncOperation
        {
            protected [__keep_incompatibility]: never;
        }
        /** Helper object for UnityWebRequests. Manages the buffering and transmission of body data during HTTP requests.
        */
        class UploadHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        /** Manage and process HTTP response body data received from a remote server.
        */
        class DownloadHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
            /** Returns true if this DownloadHandler has been informed by its parent UnityWebRequest that all data has been received, and this DownloadHandler has completed any necessary post-download processing. (Read Only)
            */
            public get isDone(): boolean;
            /** Error message describing a failure that occurred inside the download handler.
            */
            public get error(): string;
            /** Provides direct access to downloaded data.
            */
            public get nativeData(): Unity.Collections.NativeArray$1.ReadOnly<number>;
            /** Returns the raw bytes downloaded from the remote server, or null. (Read Only)
            */
            public get data(): System.Array$1<number>;
            /** Convenience property. Returns the bytes from data interpreted as a UTF8 string. (Read Only)
            */
            public get text(): string;
            /** Signals that this DownloadHandler is no longer being used, and should clean up any resources it is using.
            */
            public Dispose () : void
        }
        /** Responsible for rejecting or accepting certificates received on https requests.
        */
        class CertificateHandler extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        interface IMultipartFormSection
        {
        }
    }
    namespace UnityEngine.Networking.UnityWebRequest {
        enum Result
        { InProgress = 0, Success = 1, ConnectionError = 2, ProtocolError = 3, DataProcessingError = 4 }
    }
    namespace Unity.Collections.NativeArray$1 {
        class ReadOnly<T> extends System.ValueType implements System.Collections.Generic.IEnumerable$1<T>, System.Collections.IEnumerable
        {
            protected [__keep_incompatibility]: never;
            public [Symbol.iterator]() : IterableIterator<T>
        }
    }
    namespace UnityEngine.EventSystems {
        class UIBehaviour extends UnityEngine.MonoBehaviour
        {
            protected [__keep_incompatibility]: never;
            public IsActive () : boolean
            public IsDestroyed () : boolean
        }
        interface IEventSystemHandler
        {
        }
        interface IPointerEnterHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface ISelectHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerExitHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDeselectHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerDownHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerUpHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IMoveHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        class AbstractEventData extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class BaseEventData extends UnityEngine.EventSystems.AbstractEventData
        {
            protected [__keep_incompatibility]: never;
        }
        class AxisEventData extends UnityEngine.EventSystems.BaseEventData
        {
            protected [__keep_incompatibility]: never;
        }
        class PointerEventData extends UnityEngine.EventSystems.BaseEventData
        {
            protected [__keep_incompatibility]: never;
        }
        interface ISubmitHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IPointerClickHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IBeginDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IEndDragHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
        interface IUpdateSelectedHandler extends UnityEngine.EventSystems.IEventSystemHandler
        {
        }
    }
    namespace UnityEngine.UI {
        class Selectable extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public static get allSelectablesArray(): System.Array$1<UnityEngine.UI.Selectable>;
            public static get allSelectableCount(): number;
            public get navigation(): UnityEngine.UI.Navigation;
            public set navigation(value: UnityEngine.UI.Navigation);
            public get transition(): UnityEngine.UI.Selectable.Transition;
            public set transition(value: UnityEngine.UI.Selectable.Transition);
            public get colors(): UnityEngine.UI.ColorBlock;
            public set colors(value: UnityEngine.UI.ColorBlock);
            public get spriteState(): UnityEngine.UI.SpriteState;
            public set spriteState(value: UnityEngine.UI.SpriteState);
            public get animationTriggers(): UnityEngine.UI.AnimationTriggers;
            public set animationTriggers(value: UnityEngine.UI.AnimationTriggers);
            public get targetGraphic(): UnityEngine.UI.Graphic;
            public set targetGraphic(value: UnityEngine.UI.Graphic);
            public get interactable(): boolean;
            public set interactable(value: boolean);
            public get image(): UnityEngine.UI.Image;
            public set image(value: UnityEngine.UI.Image);
            public get animator(): UnityEngine.Animator;
            public static AllSelectablesNoAlloc ($selectables: System.Array$1<UnityEngine.UI.Selectable>) : number
            public IsInteractable () : boolean
            public FindSelectable ($dir: UnityEngine.Vector3) : UnityEngine.UI.Selectable
            public FindSelectableOnLeft () : UnityEngine.UI.Selectable
            public FindSelectableOnRight () : UnityEngine.UI.Selectable
            public FindSelectableOnUp () : UnityEngine.UI.Selectable
            public FindSelectableOnDown () : UnityEngine.UI.Selectable
            public OnMove ($eventData: UnityEngine.EventSystems.AxisEventData) : void
            public OnPointerDown ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerUp ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerEnter ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnPointerExit ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnSelect ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public OnDeselect ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public Select () : void
        }
        class Navigation extends System.ValueType implements System.IEquatable$1<UnityEngine.UI.Navigation>
        {
            protected [__keep_incompatibility]: never;
        }
        class ColorBlock extends System.ValueType implements System.IEquatable$1<UnityEngine.UI.ColorBlock>
        {
            protected [__keep_incompatibility]: never;
        }
        class SpriteState extends System.ValueType implements System.IEquatable$1<UnityEngine.UI.SpriteState>
        {
            protected [__keep_incompatibility]: never;
        }
        class AnimationTriggers extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
        class Graphic extends UnityEngine.EventSystems.UIBehaviour implements UnityEngine.UI.ICanvasElement
        {
            protected [__keep_incompatibility]: never;
        }
        interface ICanvasElement
        {
        }
        class MaskableGraphic extends UnityEngine.UI.Graphic implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement
        {
            protected [__keep_incompatibility]: never;
        }
        interface IClippable
        {
        }
        interface IMaterialModifier
        {
        }
        interface IMaskable
        {
        }
        class Image extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.ICanvasRaycastFilter, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.ILayoutElement, UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
        }
        interface ILayoutElement
        {
        }
        class Button extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public get onClick(): UnityEngine.UI.Button.ButtonClickedEvent;
            public set onClick(value: UnityEngine.UI.Button.ButtonClickedEvent);
            public OnPointerClick ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnSubmit ($eventData: UnityEngine.EventSystems.BaseEventData) : void
        }
        class InputField extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.IEndDragHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
            public get shouldHideMobileInput(): boolean;
            public set shouldHideMobileInput(value: boolean);
            public get shouldActivateOnSelect(): boolean;
            public set shouldActivateOnSelect(value: boolean);
            public get text(): string;
            public set text(value: string);
            public get isFocused(): boolean;
            public get caretBlinkRate(): number;
            public set caretBlinkRate(value: number);
            public get caretWidth(): number;
            public set caretWidth(value: number);
            public get textComponent(): UnityEngine.UI.Text;
            public set textComponent(value: UnityEngine.UI.Text);
            public get placeholder(): UnityEngine.UI.Graphic;
            public set placeholder(value: UnityEngine.UI.Graphic);
            public get caretColor(): UnityEngine.Color;
            public set caretColor(value: UnityEngine.Color);
            public get customCaretColor(): boolean;
            public set customCaretColor(value: boolean);
            public get selectionColor(): UnityEngine.Color;
            public set selectionColor(value: UnityEngine.Color);
            public get onEndEdit(): UnityEngine.UI.InputField.EndEditEvent;
            public set onEndEdit(value: UnityEngine.UI.InputField.EndEditEvent);
            public get onSubmit(): UnityEngine.UI.InputField.SubmitEvent;
            public set onSubmit(value: UnityEngine.UI.InputField.SubmitEvent);
            public get onValueChanged(): UnityEngine.UI.InputField.OnChangeEvent;
            public set onValueChanged(value: UnityEngine.UI.InputField.OnChangeEvent);
            public get onValidateInput(): UnityEngine.UI.InputField.OnValidateInput;
            public set onValidateInput(value: UnityEngine.UI.InputField.OnValidateInput);
            public get characterLimit(): number;
            public set characterLimit(value: number);
            public get contentType(): UnityEngine.UI.InputField.ContentType;
            public set contentType(value: UnityEngine.UI.InputField.ContentType);
            public get lineType(): UnityEngine.UI.InputField.LineType;
            public set lineType(value: UnityEngine.UI.InputField.LineType);
            public get inputType(): UnityEngine.UI.InputField.InputType;
            public set inputType(value: UnityEngine.UI.InputField.InputType);
            public get touchScreenKeyboard(): UnityEngine.TouchScreenKeyboard;
            public get keyboardType(): UnityEngine.TouchScreenKeyboardType;
            public set keyboardType(value: UnityEngine.TouchScreenKeyboardType);
            public get characterValidation(): UnityEngine.UI.InputField.CharacterValidation;
            public set characterValidation(value: UnityEngine.UI.InputField.CharacterValidation);
            public get readOnly(): boolean;
            public set readOnly(value: boolean);
            public get multiLine(): boolean;
            public get asteriskChar(): number;
            public set asteriskChar(value: number);
            public get wasCanceled(): boolean;
            public get caretPosition(): number;
            public set caretPosition(value: number);
            public get selectionAnchorPosition(): number;
            public set selectionAnchorPosition(value: number);
            public get selectionFocusPosition(): number;
            public set selectionFocusPosition(value: number);
            public get minWidth(): number;
            public get preferredWidth(): number;
            public get flexibleWidth(): number;
            public get minHeight(): number;
            public get preferredHeight(): number;
            public get flexibleHeight(): number;
            public get layoutPriority(): number;
            public SetTextWithoutNotify ($input: string) : void
            public MoveTextEnd ($shift: boolean) : void
            public MoveTextStart ($shift: boolean) : void
            public OnBeginDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnEndDrag ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public ProcessEvent ($e: UnityEngine.Event) : void
            public OnUpdateSelected ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public ForceLabelUpdate () : void
            public Rebuild ($update: UnityEngine.UI.CanvasUpdate) : void
            public LayoutComplete () : void
            public GraphicUpdateComplete () : void
            public ActivateInputField () : void
            public OnPointerClick ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public DeactivateInputField () : void
            public OnSubmit ($eventData: UnityEngine.EventSystems.BaseEventData) : void
            public CalculateLayoutInputHorizontal () : void
            public CalculateLayoutInputVertical () : void
        }
        class Text extends UnityEngine.UI.MaskableGraphic implements UnityEngine.UI.IClippable, UnityEngine.UI.IMaterialModifier, UnityEngine.UI.IMaskable, UnityEngine.UI.ICanvasElement, UnityEngine.UI.ILayoutElement
        {
            protected [__keep_incompatibility]: never;
        }
        enum CanvasUpdate
        { Prelayout = 0, Layout = 1, PostLayout = 2, PreRender = 3, LatePreRender = 4, MaxUpdateValue = 5 }
        class Toggle extends UnityEngine.UI.Selectable implements UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.UI.ICanvasElement, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.IMoveHandler
        {
            protected [__keep_incompatibility]: never;
            public toggleTransition : UnityEngine.UI.Toggle.ToggleTransition
            public graphic : UnityEngine.UI.Graphic
            public onValueChanged : UnityEngine.UI.Toggle.ToggleEvent
            public get group(): UnityEngine.UI.ToggleGroup;
            public set group(value: UnityEngine.UI.ToggleGroup);
            public get isOn(): boolean;
            public set isOn(value: boolean);
            public Rebuild ($executing: UnityEngine.UI.CanvasUpdate) : void
            public LayoutComplete () : void
            public GraphicUpdateComplete () : void
            public SetIsOnWithoutNotify ($value: boolean) : void
            public OnPointerClick ($eventData: UnityEngine.EventSystems.PointerEventData) : void
            public OnSubmit ($eventData: UnityEngine.EventSystems.BaseEventData) : void
        }
        class ToggleGroup extends UnityEngine.EventSystems.UIBehaviour
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.UI.Selectable {
        enum Transition
        { None = 0, ColorTint = 1, SpriteSwap = 2, Animation = 3 }
    }
    namespace UnityEngine.UI.Button {
        class ButtonClickedEvent extends UnityEngine.Events.UnityEvent implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
            public constructor ()
        }
    }
    namespace UnityEngine.UI.InputField {
        class EndEditEvent extends UnityEngine.Events.UnityEvent$1<string> implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
        }
        class SubmitEvent extends UnityEngine.Events.UnityEvent$1<string> implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
        }
        class OnChangeEvent extends UnityEngine.Events.UnityEvent$1<string> implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
        }
        interface OnValidateInput
        { 
        (text: string, charIndex: number, addedChar: number) : number; 
        Invoke?: (text: string, charIndex: number, addedChar: number) => number;
        }
        var OnValidateInput: { new (func: (text: string, charIndex: number, addedChar: number) => number): OnValidateInput; }
        enum ContentType
        { Standard = 0, Autocorrected = 1, IntegerNumber = 2, DecimalNumber = 3, Alphanumeric = 4, Name = 5, EmailAddress = 6, Password = 7, Pin = 8, Custom = 9 }
        enum LineType
        { SingleLine = 0, MultiLineSubmit = 1, MultiLineNewline = 2 }
        enum InputType
        { Standard = 0, AutoCorrect = 1, Password = 2 }
        enum CharacterValidation
        { None = 0, Integer = 1, Decimal = 2, Alphanumeric = 3, Name = 4, EmailAddress = 5 }
    }
    namespace UnityEngine.UI.Toggle {
        enum ToggleTransition
        { None = 0, Fade = 1 }
        class ToggleEvent extends UnityEngine.Events.UnityEvent$1<boolean> implements UnityEngine.ISerializationCallbackReceiver
        {
            protected [__keep_incompatibility]: never;
            public constructor ()
        }
    }
    namespace ALM.Screens.Mission {
        class JsConfigure extends System.Object implements System.IEquatable$1<ALM.Screens.Mission.JsConfigure>
        {
            protected [__keep_incompatibility]: never;
            public get Raycaster(): ALM.Screens.Mission.RaycasterService;
            public set Raycaster(value: ALM.Screens.Mission.RaycasterService);
            public get BallPool(): ALM.Screens.Mission.BallPoolService;
            public set BallPool(value: ALM.Screens.Mission.BallPoolService);
            public get Audio(): ALM.Screens.Base.AudioService;
            public set Audio(value: ALM.Screens.Base.AudioService);
            public get Score(): ALM.Screens.Mission.MissionScoreData;
            public set Score(value: ALM.Screens.Mission.MissionScoreData);
            public static op_Inequality ($left: ALM.Screens.Mission.JsConfigure, $right: ALM.Screens.Mission.JsConfigure) : boolean
            public static op_Equality ($left: ALM.Screens.Mission.JsConfigure, $right: ALM.Screens.Mission.JsConfigure) : boolean
            public Equals ($obj: any) : boolean
            public Equals ($other: ALM.Screens.Mission.JsConfigure) : boolean
            public Deconstruct ($Raycaster: $Ref<ALM.Screens.Mission.RaycasterService>, $BallPool: $Ref<ALM.Screens.Mission.BallPoolService>, $Audio: $Ref<ALM.Screens.Base.AudioService>, $Score: $Ref<ALM.Screens.Mission.MissionScoreData>) : void
            public constructor ($Raycaster: ALM.Screens.Mission.RaycasterService, $BallPool: ALM.Screens.Mission.BallPoolService, $Audio: ALM.Screens.Base.AudioService, $Score: ALM.Screens.Mission.MissionScoreData)
            public static Equals ($objA: any, $objB: any) : boolean
            public constructor ()
        }
        class RaycasterService extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public add_OnCastBegin ($value: System.Action) : void
            public remove_OnCastBegin ($value: System.Action) : void
            public add_OnCastFinished ($value: System.Action$1<ALM.Screens.Mission.IRaycastTarget>) : void
            public remove_OnCastFinished ($value: System.Action$1<ALM.Screens.Mission.IRaycastTarget>) : void
            public Cast ($raycaster: ALM.Screens.Mission.IRaycaster) : void
            public constructor ()
        }
        class BallPoolService extends System.Object implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
            public get Pool(): UnityEngine.Pool.ObjectPool$1<ALM.Screens.Mission.Ball>;
            public add_OnBallHit ($value: System.Action$1<ALM.Screens.Mission.Ball>) : void
            public remove_OnBallHit ($value: System.Action$1<ALM.Screens.Mission.Ball>) : void
            public Ball ($typeIndex?: number) : ALM.Screens.Mission.Ball
            public GetBalls ($count: number, $type?: number) : System.Array$1<ALM.Screens.Mission.Ball>
            public Dispose () : void
            public constructor ($scope: ALM.Screens.Mission.MissionLifetimeScope, $missionScoreData: ALM.Screens.Mission.MissionScoreData, $objectSetting: ALM.Screens.Base.Setting.ObjectSetting, $audioService: ALM.Screens.Base.AudioService, $audioSetting: ALM.Screens.Base.AudioSetting, $mission: ALM.Screens.Base.MissionLoader.PlayableMission)
            public constructor ()
        }
        class MissionScoreData extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public get Score(): number;
            public set Score(value: number);
            public get Accuracy(): number;
            public set Accuracy(value: number);
            public get ReactionTime(): number;
            public set ReactionTime(value: number);
            public add_OnScoreChanged ($value: System.Action$1<number>) : void
            public remove_OnScoreChanged ($value: System.Action$1<number>) : void
            public add_OnAccuracyChange ($value: System.Action$1<number>) : void
            public remove_OnAccuracyChange ($value: System.Action$1<number>) : void
            public add_OnReactionTimeChange ($value: System.Action$1<number>) : void
            public remove_OnReactionTimeChange ($value: System.Action$1<number>) : void
            public constructor ()
        }
        interface JsConfigureDel
        { 
        (configure: ALM.Screens.Mission.JsConfigure) : void; 
        Invoke?: (configure: ALM.Screens.Mission.JsConfigure) => void;
        }
        var JsConfigureDel: { new (func: (configure: ALM.Screens.Mission.JsConfigure) => void): JsConfigureDel; }
        class Ball extends UnityEngine.MonoBehaviour implements ALM.Common.IManagedTickable, ALM.Screens.Mission.IRaycastTarget
        {
            protected [__keep_incompatibility]: never;
            public get TypeIndex(): number;
            public set TypeIndex(value: number);
            public set Color(value: UnityEngine.Color);
            public get Hp(): number;
            public set Hp(value: number);
            public add_OnHitBy ($value: System.Action$1<number>) : void
            public remove_OnHitBy ($value: System.Action$1<number>) : void
            public add_OnHit ($value: System.Action) : void
            public remove_OnHit ($value: System.Action) : void
            public Tick () : void
            public HitBy ($index: number) : void
            public HasHpBar () : ALM.Screens.Mission.Ball
            public constructor ()
        }
        interface IRaycastTarget
        {
            add_OnHitBy ($value: System.Action$1<number>) : void
            remove_OnHitBy ($value: System.Action$1<number>) : void
            add_OnHit ($value: System.Action) : void
            remove_OnHit ($value: System.Action) : void
            HitBy ($index: number) : void
        }
        class MissionEntry extends ALM.Screens.Base.HandlableEntry$1<ALM.Screens.Mission.MissionEntry> implements VContainer.Unity.IStartable, VContainer.Unity.ITickable, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class MissionLifetimeScope extends ALM.Screens.Base.HandlableLifetimeScope$2<ALM.Screens.Mission.MissionLifetimeScope, ALM.Screens.Mission.MissionEntry> implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        interface IRaycaster
        {
        }
    }
    namespace ALM.Screens.Base {
        class AudioService extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public _activeSources : System.Collections.Generic.List$1<UnityEngine.AudioSource>
            public get Pool(): UnityEngine.Pool.ObjectPool$1<UnityEngine.AudioSource>;
            public PlaySoundAtPos ($clip: UnityEngine.AudioClip, $pos: UnityEngine.Vector3, $addtionSetting?: System.Action$1<UnityEngine.AudioSource>) : void
            public PlaySoundAtPosAsync ($clip: UnityEngine.AudioClip, $pos: UnityEngine.Vector3, $addtionSetting?: System.Action$1<UnityEngine.AudioSource>) : Cysharp.Threading.Tasks.UniTask
            public RegisterSource ($source: UnityEngine.AudioSource) : void
            public BindTo ($parent: UnityEngine.Transform) : UnityEngine.AudioSource
            public Pause () : void
            public Resume () : void
            public constructor ($audioSetting: ALM.Screens.Base.AudioSetting)
            public constructor ()
        }
        class HandlableEntry$1<TEntry> extends System.Object implements VContainer.Unity.IStartable, VContainer.Unity.ITickable, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class HandlableLifetimeScope$2<TScope, TEntry> extends VContainer.Unity.LifetimeScope implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        class AudioSetting extends System.Object implements ALM.Util.UIToolkitExtend.IDataTarget
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace ALM.Common {
        interface IManagedTickable
        {
        }
    }
    namespace UnityEngine.Pool {
        class ObjectPool$1<T> extends System.Object implements UnityEngine.Pool.IObjectPool$1<T>, System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        interface IObjectPool$1<T>
        {
        }
    }
    namespace VContainer.Unity {
        class LifetimeScope extends UnityEngine.MonoBehaviour implements System.IDisposable
        {
            protected [__keep_incompatibility]: never;
        }
        interface IStartable
        {
        }
        interface ITickable
        {
        }
    }
    namespace ALM.Screens.Base.Setting {
        class ObjectSetting extends System.Object implements ALM.Util.UIToolkitExtend.IDataTarget
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace ALM.Util.UIToolkitExtend {
        interface IDataTarget
        {
        }
    }
    namespace ALM.Screens.Base.MissionLoader {
        class PlayableMission extends System.Object implements System.IEquatable$1<ALM.Screens.Base.MissionLoader.PlayableMission>
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace UnityEngine.Audio {
        /** Represents an audio resource asset that you can play through an AudioSource.
        */
        class AudioResource extends UnityEngine.Object
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace Cysharp.Threading.Tasks {
        class UniTask extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
        class UniTask$1<T> extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace ALM.Util {
        class FileIO extends System.Object
        {
            protected [__keep_incompatibility]: never;
            public static LoadExternalSoundSync ($path: string, $cb: System.Action$1<UnityEngine.AudioClip>, $ct?: System.Threading.CancellationToken) : void
            public static LoadExternalSoundAsync ($path: string, $ct?: System.Threading.CancellationToken) : Cysharp.Threading.Tasks.UniTask$1<UnityEngine.AudioClip>
            public static GetPath ($subPath: string, $name?: string) : string
            public static CopyDirectory ($source: string, $dest: string) : void
            public static OpenFolder ($path: string, $absolutePath?: boolean) : void
            public static GetMissionFolder ($missionName: string) : string
            public static ParseExtension ($extension: ALM.Util.FileIO.Extension) : System.Array$1<SFB.ExtensionFilter>
        }
    }
    namespace Newtonsoft.Json {
        /** Converts an object to and from JSON.
        */
        class JsonConverter extends System.Object
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace SFB {
        class ExtensionFilter extends System.ValueType
        {
            protected [__keep_incompatibility]: never;
        }
    }
    namespace ALM.Util.FileIO {
        class Extension extends System.Object implements System.IEquatable$1<ALM.Util.FileIO.Extension>
        {
            protected [__keep_incompatibility]: never;
        }
        interface Extension {
            ParseExtension () : System.Array$1<SFB.ExtensionFilter>;
        }
    }
}
