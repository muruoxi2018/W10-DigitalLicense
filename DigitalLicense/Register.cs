using Microsoft.Win32;
using System;

public class Register
{
    /// <summary>  
    /// 注册表基项静态域  
    ///1.Registry.ClassesRoot 对应于HKEY_CLASSES_ROOT 主键  
    ///2.Registry.CurrentUser 对应于HKEY_CURRENT_USER 主键  
    ///3.Registry.LocalMachine 对应于 HKEY_LOCAL_MACHINE 主键  
    ///4.Registry.User 对应于 HKEY_USER 主键  
    ///5.Registry.CurrentConfig 对应于HEKY_CURRENT_CONFIG 主键  
    ///6.Registry.DynDa 对应于HKEY_DYN_DATA 主键  
    ///7.Registry.PerformanceData 对应于HKEY_PERFORMANCE_DATA 主键  
    /// </summary>  
    public enum RegDomain
    {
        /// <summary>  
        /// 对应于HKEY_CLASSES_ROOT 主键  
        /// </summary>  
        ClassesRoot = 0,

        /// <summary>  
        /// 对应于HKEY_CURRENT_USER 主键  
        /// </summary>  
        CurrentUser = 1,

        /// <summary>  
        /// 对应于 HKEY_LOCAL_MACHINE 主键  
        /// </summary>  
        LocalMachine = 2,

        /// <summary>  
        /// 对应于 HKEY_USER 主键  
        /// </summary>  
        User = 3,

        /// <summary>  
        /// 对应于HEKY_CURRENT_CONFIG 主键  
        /// </summary>  
        CurrentConfig = 4,

        /// <summary>  
        /// 对应于HKEY_DYN_DATA 主键  
        /// </summary>  
        DynDa = 5,

        /// <summary>  
        /// 对应于HKEY_PERFORMANCE_DATA 主键  
        /// </summary>  
        PerformanceData = 6
    }


    /// <summary>  
    /// 指定在注册表中存储值时所用的数据类型，或标识注册表中某个值的数据类型  
    ///1.RegistryValueKind.Unknown  
    ///2.RegistryValueKind.String  
    ///3.RegistryValueKind.ExpandString  
    ///4.RegistryValueKind.Binary  
    ///5.RegistryValueKind.DWord  
    ///6.RegistryValueKind.MultiString  
    ///7.RegistryValueKind.QWord  
    /// </summary>  
    public enum RegValueKind
    {
        /// <summary>  
        /// 指示一个不受支持的注册表数据类型。例如，不支持 Microsoft Win API 注册表数据类型 REG_RESOURCE_LIST。使用此值指定  
        /// </summary>  
        Unknown = 0,
        /// <summary>  
        /// 指定一个以 Null 结尾的字符串。此值与 Win API 注册表数据类型 REG_SZ 等效。  
        /// </summary>  
        String = 1,
        /// <summary>  
        /// 指定一个以 NULL 结尾的字符串，该字符串中包含对环境变量（如 %PATH%，当值被检索时，就会展开）的未展开的引用。  
        /// 此值与 Win API 注册表数据类型 REG_EXPAND_SZ 等效。  
        /// </summary>  
        ExpandString = 2,
        /// <summary>  
        /// 指定任意格式的二进制数据。此值与 Win API 注册表数据类型 REG_BINARY 等效。  
        /// </summary>  
        Binary = 3,
        /// <summary>  
        /// 指定一个  位二进制数。此值与 Win API 注册表数据类型 REG_DWORD 等效。  
        /// </summary>  
        DWord = 4,
        /// <summary>  
        /// 指定一个以 NULL 结尾的字符串数组，以两个空字符结束。此值与 WinAPI 注册表数据类型 REG_MULTI_SZ 等效。  
        /// </summary>  
        MultiString = 5,
        /// <summary>  
        /// 指定一个  位二进制数。此值与 Win API 注册表数据类型 REG_QWORD 等效。  
        /// </summary>  
        QWord = 6
    }
    #region 字段定义  

    /// <summary>  
    /// 注册表项名称  
    /// </summary>  
    private string _subkey;
    /// <summary>  
    /// 注册表基项域  
    /// </summary>  
    private RegDomain _domain;
    /// <summary>  
    /// 注册表键值  
    /// </summary>  
    private string _regeditkey;

    #endregion

    #region 属性  

    /// <summary>  
    /// 设置注册表项名称  
    /// </summary>  
    public string SubKey
    {
        //get { return _subkey; }  
        set { _subkey = value; }
    }

    /// <summary>  
    /// 注册表基项域  
    /// </summary>  
    public RegDomain Domain
    {
        //get { return _domain; }  
        set { _domain = value; }
    }

    /// <summary>  
    /// 注册表键值  
    /// </summary>  
    public string RegeditKey
    {
        ///get{return _regeditkey;}  
        set { _regeditkey = value; }
    }

    #endregion

    #region 构造函数  


    /// <summary>  
    /// 注册表操作类  
    ///1.创建注册表项  
    ///2.读取注册表项  
    ///3.判断注册表项是否存在  
    ///4.删除注册表项  
    ///5.创建注册表键值  
    ///6.读取注册表键值  
    ///7.判断注册表键值是否存在  
    ///8.删除注册表键值  
    /// </summary>  


    public Register()
    {
        ///默认注册表项名称  
        _subkey = "software\\";
        ///默认注册表基项域  
        _domain = RegDomain.LocalMachine;
    }

    /// <summary>  
    /// 构造函数  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    public Register(string subKey, RegDomain regDomain)
    {
        ///设置注册表项名称  
        _subkey = subKey;
        ///设置注册表基项域  
        _domain = regDomain;
    }

    #endregion

    #region 公有方法  

    #region 创建注册表项  

    /// <summary>  
    /// 创建注册表项，默认创建在注册表基项 HKEY_LOCAL_MACHINE 下面（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    public virtual void CreateSubKey()
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (_subkey == string.Empty || _subkey == null)
        {
            return;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        ///要创建的注册表项的节点  
        RegistryKey sKey;
        if (!IsSubKeyExist())
        {
            sKey = key.CreateSubKey(_subkey);
        }
        //sKey.Close();  
        ///关闭对注册表项的更改  
        key.Close();
    }

    /// <summary>  
    /// 创建注册表项，默认创建在注册表基项 HKEY_LOCAL_MACHINE 下面  
    /// 虚方法，子类可进行重写  
    /// 例子：如subkey 是software\\higame\\，则将创建HKEY_LOCAL_MACHINE\\software\\higame\\注册表项  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    public virtual void CreateSubKey(string subKey)
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (subKey == string.Empty || subKey == null)
        {
            return;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        ///要创建的注册表项的节点  
        RegistryKey sKey;
        if (!IsSubKeyExist(subKey))
        {
            sKey = key.CreateSubKey(subKey);
        }
        //sKey.Close();  
        ///关闭对注册表项的更改  
        key.Close();
    }

    /// <summary>  
    /// 创建注册表项，默认创建在注册表基项 HKEY_LOCAL_MACHINE 下面  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="regDomain">注册表基项域</param>  
    public virtual void CreateSubKey(RegDomain regDomain)
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (_subkey == string.Empty || _subkey == null)
        {
            return;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(regDomain);

        ///要创建的注册表项的节点  
        RegistryKey sKey;
        if (!IsSubKeyExist(regDomain))
        {
            sKey = key.CreateSubKey(_subkey);
        }
        //sKey.Close();  
        ///关闭对注册表项的更改  
        key.Close();
    }

    /// <summary>  
    /// 创建注册表项（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// 例子：如regDomain 是HKEY_LOCAL_MACHINE，subkey 是software\\higame\\，则将创建HKEY_LOCAL_MACHINE\\software\\higame\\注册表项  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    public virtual void CreateSubKey(string subKey, RegDomain regDomain)
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (subKey == string.Empty || subKey == null)
        {
            return;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(regDomain);

        ///要创建的注册表项的节点  
        RegistryKey sKey;
        if (!IsSubKeyExist(subKey, regDomain))
        {
            sKey = key.CreateSubKey(subKey);
        }
        //sKey.Close();  
        ///关闭对注册表项的更改  
        key.Close();
    }

    #endregion

    #region 判断注册表项是否存在  

    /// <summary>  
    /// 判断注册表项是否存在，默认是在注册表基项HKEY_LOCAL_MACHINE 下判断（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// 例子：如果设置了Domain 和SubKey 属性，则判断Domain\\SubKey，否则默认判断HKEY_LOCAL_MACHINE\\software\\  
    /// </summary>  
    /// <returns>返回注册表项是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsSubKeyExist()
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (_subkey == string.Empty || _subkey == null)
        {
            return false;
        }

        ///检索注册表子项  
        ///如果sKey 为null,说明没有该注册表项不存在，否则存在  
        RegistryKey sKey = OpenSubKey(_subkey, _domain);
        if (sKey == null)
        {
            return false;
        }
        return true;
    }

    /// <summary>  
    /// 判断注册表项是否存在，默认是在注册表基项HKEY_LOCAL_MACHINE 下判断  
    /// 虚方法，子类可进行重写  
    /// 例子：如subkey 是software\\higame\\，则将判断HKEY_LOCAL_MACHINE\\software\\higame\\注册表项是否存在  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <returns>返回注册表项是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsSubKeyExist(string subKey)
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (subKey == string.Empty || subKey == null)
        {
            return false;
        }

        ///检索注册表子项  
        ///如果sKey 为null,说明没有该注册表项不存在，否则存在  
        RegistryKey sKey = OpenSubKey(subKey);
        if (sKey == null)
        {
            return false;
        }
        return true;
    }

    /// <summary>  
    /// 判断注册表项是否存在  
    /// 虚方法，子类可进行重写  
    /// 例子：如regDomain 是HKEY_CLASSES_ROOT，则将判断HKEY_CLASSES_ROOT\\SubKey 注册表项是否存在  
    /// </summary>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>返回注册表项是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsSubKeyExist(RegDomain regDomain)
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (_subkey == string.Empty || _subkey == null)
        {
            return false;
        }

        ///检索注册表子项  
        ///如果sKey 为null,说明没有该注册表项不存在，否则存在  
        RegistryKey sKey = OpenSubKey(_subkey, regDomain);
        if (sKey == null)
        {
            return false;
        }
        return true;
    }

    /// <summary>  
    /// 判断注册表项是否存在（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// 例子：如regDomain 是HKEY_CLASSES_ROOT，subkey 是software\\higame\\，则将判断HKEY_CLASSES_ROOT\\software\\higame\\注册表项是否存在  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>返回注册表项是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsSubKeyExist(string subKey, RegDomain regDomain)
    {
        ///判断注册表项名称是否为空，如果为空，返回false  
        if (subKey == string.Empty || subKey == null)
        {
            return false;
        }

        ///检索注册表子项  
        ///如果sKey 为null,说明没有该注册表项不存在，否则存在  
        RegistryKey sKey = OpenSubKey(subKey, regDomain);
        if (sKey == null)
        {
            return false;
        }
        return true;
    }

    #endregion

    #region 删除注册表项  

    /// <summary>  
    /// 删除注册表项（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <returns>如果删除成功，则返回true，否则为false</returns>  
    public virtual bool DeleteSubKey()
    {
        ///返回删除是否成功  
        bool result = false;

        ///判断注册表项名称是否为空，如果为空，返回false  
        if (_subkey == string.Empty || _subkey == null)
        {
            return false;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        if (IsSubKeyExist())
        {
            try
            {
                ///删除注册表项  
                key.DeleteSubKey(_subkey);
                result = true;
            }
            catch
            {
                result = false;
            }
        }
        ///关闭对注册表项的更改  
        key.Close();
        return result;
    }

    /// <summary>  
    /// 删除注册表项（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <returns>如果删除成功，则返回true，否则为false</returns>  
    public virtual bool DeleteSubKey(string subKey)
    {
        ///返回删除是否成功  
        bool result = false;

        ///判断注册表项名称是否为空，如果为空，返回false  
        if (subKey == string.Empty || subKey == null)
        {
            return false;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        if (IsSubKeyExist())
        {
            try
            {
                ///删除注册表项  
                key.DeleteSubKey(subKey);
                result = true;
            }
            catch
            {
                result = false;
            }
        }
        ///关闭对注册表项的更改  
        key.Close();
        return result;
    }

    /// <summary>  
    /// 删除注册表项  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>如果删除成功，则返回true，否则为false</returns>  
    public virtual bool DeleteSubKey(string subKey, RegDomain regDomain)
    {
        ///返回删除是否成功  
        bool result = false;

        ///判断注册表项名称是否为空，如果为空，返回false  
        if (subKey == string.Empty || subKey == null)
        {
            return false;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(regDomain);

        if (IsSubKeyExist(subKey, regDomain))
        {
            try
            {
                ///删除注册表项  
                key.DeleteSubKey(subKey);
                result = true;
            }
            catch
            {
                result = false;
            }
        }
        ///关闭对注册表项的更改  
        key.Close();
        return result;
    }

    #endregion

    #region 判断键值是否存在  

    /// <summary>  
    /// 判断键值是否存在（请先设置SubKey 和RegeditKey 属性）  
    /// 虚方法，子类可进行重写  
    /// .如果RegeditKey 为空、null，则返回false  
    /// .如果SubKey 为空、null 或者SubKey 指定的注册表项不存在，返回false  
    /// </summary>  
    /// <returns>返回键值是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsRegeditKeyExist()
    {
        ///返回结果  
        bool result = false;

        ///判断是否设置键值属性  
        if (_regeditkey == string.Empty || _regeditkey == null)
        {
            return false;
        }

        ///判断注册表项是否存在  
        if (IsSubKeyExist())
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey();
            ///键值集合  
            string[] regeditKeyNames;
            ///获取键值集合  
            regeditKeyNames = key.GetValueNames();
            ///遍历键值集合，如果存在键值，则退出遍历  
            foreach (string regeditKey in regeditKeyNames)
            {
                if (string.Compare(regeditKey, _regeditkey, true) == 0)
                {
                    result = true;
                    break;
                }
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    /// <summary>  
    /// 判断键值是否存在（请先设置SubKey 属性）  
    /// 虚方法，子类可进行重写  
    /// 如果SubKey 为空、null 或者SubKey 指定的注册表项不存在，返回false  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <returns>返回键值是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsRegeditKeyExist(string name)
    {
        ///返回结果  
        bool result = false;

        ///判断是否设置键值属性  
        if (name == string.Empty || name == null)
        {
            return false;
        }

        ///判断注册表项是否存在  
        if (IsSubKeyExist())
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey();
            ///键值集合  
            string[] regeditKeyNames;
            ///获取键值集合  
            regeditKeyNames = key.GetValueNames();
            ///遍历键值集合，如果存在键值，则退出遍历  
            foreach (string regeditKey in regeditKeyNames)
            {
                if (string.Compare(regeditKey, name, true) == 0)
                {
                    result = true;
                    break;
                }
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    /// <summary>  
    /// 判断键值是否存在  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="subKey">注册表项名称</param>  
    /// <returns>返回键值是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsRegeditKeyExist(string name, string subKey)
    {
        ///返回结果  
        bool result = false;

        ///判断是否设置键值属性  
        if (name == string.Empty || name == null)
        {
            return false;
        }

        ///判断注册表项是否存在  
        if (IsSubKeyExist())
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey(subKey);
            ///键值集合  
            string[] regeditKeyNames;
            ///获取键值集合  
            regeditKeyNames = key.GetValueNames();
            ///遍历键值集合，如果存在键值，则退出遍历  
            foreach (string regeditKey in regeditKeyNames)
            {
                if (string.Compare(regeditKey, name, true) == 0)
                {
                    result = true;
                    break;
                }
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    /// <summary>  
    /// 判断键值是否存在  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>返回键值是否存在，存在返回true，否则返回false</returns>  
    public virtual bool IsRegeditKeyExist(string name, string subKey, RegDomain regDomain)
    {
        ///返回结果  
        bool result = false;

        ///判断是否设置键值属性  
        if (name == string.Empty || name == null)
        {
            return false;
        }

        ///判断注册表项是否存在  
        if (IsSubKeyExist())
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey(subKey, regDomain);
            ///键值集合  
            string[] regeditKeyNames;
            ///获取键值集合  
            regeditKeyNames = key.GetValueNames();
            ///遍历键值集合，如果存在键值，则退出遍历  
            foreach (string regeditKey in regeditKeyNames)
            {
                if (string.Compare(regeditKey, name, true) == 0)
                {
                    result = true;
                    break;
                }
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    #endregion

    #region 设置键值内容  

    /// <summary>  
    /// 设置指定的键值内容，不指定内容数据类型（请先设置RegeditKey 和SubKey 属性）  
    /// 存在改键值则修改键值内容，不存在键值则先创建键值，再设置键值内容  
    /// </summary>  
    /// <param name="content">键值内容</param>  
    /// <returns>键值内容设置成功，则返回true，否则返回false</returns>  
    public virtual bool WriteRegeditKey(object content)
    {
        ///返回结果  
        bool result = false;

        ///判断是否设置键值属性  
        if (_regeditkey == string.Empty || _regeditkey == null)
        {
            return false;
        }

        ///判断注册表项是否存在，如果不存在，则直接创建  
        if (!IsSubKeyExist(_subkey))
        {
            CreateSubKey(_subkey);
        }

        ///以可写方式打开注册表项  
        RegistryKey key = OpenSubKey(true);

        ///如果注册表项打开失败，则返回false  
        if (key == null)
        {
            return false;
        }

        try
        {
            key.SetValue(_regeditkey, content);
            result = true;
        }
        catch
        {
            result = false;
        }
        finally
        {
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    /// <summary>  
    /// 设置指定的键值内容，不指定内容数据类型（请先设置SubKey 属性）  
    /// 存在改键值则修改键值内容，不存在键值则先创建键值，再设置键值内容  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="content">键值内容</param>  
    /// <returns>键值内容设置成功，则返回true，否则返回false</returns>  
    public virtual bool WriteRegeditKey(string name, object content)
    {
        ///返回结果  
        bool result = false;

        ///判断键值是否存在  
        if (name == string.Empty || name == null)
        {
            return false;
        }

        ///判断注册表项是否存在，如果不存在，则直接创建  
        if (!IsSubKeyExist(_subkey))
        {
            CreateSubKey(_subkey);
        }

        ///以可写方式打开注册表项  
        RegistryKey key = OpenSubKey(true);

        ///如果注册表项打开失败，则返回false  
        if (key == null)
        {
            return false;
        }

        try
        {
            key.SetValue(name, content);
            result = true;
        }
        catch
        {
            result = false;
        }
        finally
        {
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    /// <summary>  
    /// 设置指定的键值内容，指定内容数据类型（请先设置SubKey 属性）  
    /// 存在改键值则修改键值内容，不存在键值则先创建键值，再设置键值内容  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="content">键值内容</param>  
    /// <returns>键值内容设置成功，则返回true，否则返回false</returns>  
    public virtual bool WriteRegeditKey(string name, object content, RegValueKind regValueKind)
    {
        ///返回结果  
        bool result = false;

        ///判断键值是否存在  
        if (name == string.Empty || name == null)
        {
            return false;
        }

        ///判断注册表项是否存在，如果不存在，则直接创建  
        if (!IsSubKeyExist(_subkey))
        {
            CreateSubKey(_subkey);
        }

        ///以可写方式打开注册表项  
        RegistryKey key = OpenSubKey(true);

        ///如果注册表项打开失败，则返回false  
        if (key == null)
        {
            return false;
        }

        try
        {
            key.SetValue(name, content, GetRegValueKind(regValueKind));
            result = true;
        }
        catch
        {
            result = false;
        }
        finally
        {
            ///关闭对注册表项的更改  
            key.Close();
        }
        return result;
    }

    #endregion

    #region 读取键值内容  

    /// <summary>  
    /// 读取键值内容（请先设置RegeditKey 和SubKey 属性）  
    /// .如果RegeditKey 为空、null 或者RegeditKey 指示的键值不存在，返回null  
    /// .如果SubKey 为空、null 或者SubKey 指示的注册表项不存在，返回null  
    /// .反之，则返回键值内容  
    /// </summary>  
    /// <returns>返回键值内容</returns>  
    public virtual object ReadRegeditKey()
    {
        ///键值内容结果  
        object obj = null;

        ///判断是否设置键值属性  
        if (_regeditkey == string.Empty || _regeditkey == null)
        {
            return null;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(_regeditkey))
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey();
            if (key != null)
            {
                obj = key.GetValue(_regeditkey);
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return obj;
    }

    /// <summary>  
    /// 读取键值内容（请先设置SubKey 属性）  
    /// .如果SubKey 为空、null 或者SubKey 指示的注册表项不存在，返回null  
    /// .反之，则返回键值内容  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <returns>返回键值内容</returns>  
    public virtual object ReadRegeditKey(string name)
    {
        ///键值内容结果  
        object obj = null;

        ///判断是否设置键值属性  
        if (name == string.Empty || name == null)
        {
            return null;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(name))
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey();
            if (key != null)
            {
                obj = key.GetValue(name);
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return obj;
    }

    /// <summary>  
    /// 读取键值内容  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="subKey">注册表项名称</param>  
    /// <returns>返回键值内容</returns>  
    public virtual object ReadRegeditKey(string name, string subKey)
    {
        ///键值内容结果  
        object obj = null;

        ///判断是否设置键值属性  
        if (name == string.Empty || name == null)
        {
            return null;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(name))
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey(subKey);
            if (key != null)
            {
                obj = key.GetValue(name);
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return obj;
    }

    /// <summary>  
    /// 读取键值内容  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>返回键值内容</returns>  
    public virtual object ReadRegeditKey(string name, string subKey, RegDomain regDomain)
    {
        ///键值内容结果  
        object obj = null;

        ///判断是否设置键值属性  
        if (name == string.Empty || name == null)
        {
            return null;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(name))
        {
            ///打开注册表项  
            RegistryKey key = OpenSubKey(subKey, regDomain);
            if (key != null)
            {
                obj = key.GetValue(name);
            }
            ///关闭对注册表项的更改  
            key.Close();
        }
        return obj;
    }

    #endregion

    #region 删除键值  

    /// <summary>  
    /// 删除键值（请先设置RegeditKey 和SubKey 属性）  
    /// .如果RegeditKey 为空、null 或者RegeditKey 指示的键值不存在，返回false  
    /// .如果SubKey 为空、null 或者SubKey 指示的注册表项不存在，返回false  
    /// </summary>  
    /// <returns>如果删除成功，返回true，否则返回false</returns>  
    public virtual bool DeleteRegeditKey()
    {
        ///删除结果  
        bool result = false;

        ///判断是否设置键值属性，如果没有设置，则返回false  
        if (_regeditkey == string.Empty || _regeditkey == null)
        {
            return false;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(_regeditkey))
        {
            ///以可写方式打开注册表项  
            RegistryKey key = OpenSubKey(true);
            if (key != null)
            {
                try
                {
                    ///删除键值  
                    key.DeleteValue(_regeditkey);
                    result = true;
                }
                catch
                {
                    result = false;
                }
                finally
                {
                    ///关闭对注册表项的更改  
                    key.Close();
                }
            }
        }

        return result;
    }

    /// <summary>  
    /// 删除键值（请先设置SubKey 属性）  
    /// 如果SubKey 为空、null 或者SubKey 指示的注册表项不存在，返回false  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <returns>如果删除成功，返回true，否则返回false</returns>  
    public virtual bool DeleteRegeditKey(string name)
    {
        ///删除结果  
        bool result = false;

        ///判断键值名称是否为空，如果为空，则返回false  
        if (name == string.Empty || name == null)
        {
            return false;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(name))
        {
            ///以可写方式打开注册表项  
            RegistryKey key = OpenSubKey(true);
            if (key != null)
            {
                try
                {
                    ///删除键值  
                    key.DeleteValue(name);
                    result = true;
                }
                catch
                {
                    result = false;
                }
                finally
                {
                    ///关闭对注册表项的更改  
                    key.Close();
                }
            }
        }

        return result;
    }

    /// <summary>  
    /// 删除键值  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="subKey">注册表项名称</param>  
    /// <returns>如果删除成功，返回true，否则返回false</returns>  
    public virtual bool DeleteRegeditKey(string name, string subKey)
    {
        ///删除结果  
        bool result = false;

        ///判断键值名称和注册表项名称是否为空，如果为空，则返回false  
        if (name == string.Empty || name == null || subKey == string.Empty || subKey == null)
        {
            return false;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(name))
        {
            ///以可写方式打开注册表项  
            RegistryKey key = OpenSubKey(subKey, true);
            if (key != null)
            {
                try
                {
                    ///删除键值  
                    key.DeleteValue(name);
                    result = true;
                }
                catch
                {
                    result = false;
                }
                finally
                {
                    ///关闭对注册表项的更改  
                    key.Close();
                }
            }
        }

        return result;
    }

    /// <summary>  
    /// 删除键值  
    /// </summary>  
    /// <param name="name">键值名称</param>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>如果删除成功，返回true，否则返回false</returns>  
    public virtual bool DeleteRegeditKey(string name, string subKey, RegDomain regDomain)
    {
        ///删除结果  
        bool result = false;

        ///判断键值名称和注册表项名称是否为空，如果为空，则返回false  
        if (name == string.Empty || name == null || subKey == string.Empty || subKey == null)
        {
            return false;
        }

        ///判断键值是否存在  
        if (IsRegeditKeyExist(name))
        {
            ///以可写方式打开注册表项  
            RegistryKey key = OpenSubKey(subKey, regDomain, true);
            if (key != null)
            {
                try
                {
                    ///删除键值  
                    key.DeleteValue(name);
                    result = true;
                }
                catch
                {
                    result = false;
                }
                finally
                {
                    ///关闭对注册表项的更改  
                    key.Close();
                }
            }
        }

        return result;
    }

    #endregion

    #endregion

    #region 受保护方法  

    /// <summary>  
    /// 获取注册表基项域对应顶级节点  
    /// 例子：如regDomain 是ClassesRoot，则返回Registry.ClassesRoot  
    /// </summary>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>注册表基项域对应顶级节点</returns>  
    protected RegistryKey GetRegDomain(RegDomain regDomain)
    {
        ///创建基于注册表基项的节点  
        RegistryKey key;

        #region 判断注册表基项域  
        switch (regDomain)
        {
            case RegDomain.ClassesRoot:
                key = Registry.ClassesRoot; break;
            case RegDomain.CurrentUser:
                key = Registry.CurrentUser; break;
            case RegDomain.LocalMachine:
                key = Registry.LocalMachine; break;
            case RegDomain.User:
                key = Registry.Users; break;
            case RegDomain.CurrentConfig:
                key = Registry.CurrentConfig; break;
            case RegDomain.DynDa:
                key = Registry.DynData; break;
            case RegDomain.PerformanceData:
                key = Registry.PerformanceData; break;
            default:
                key = Registry.LocalMachine; break;
        }
        #endregion

        return key;
    }

    /// <summary>  
    /// 获取在注册表中对应的值数据类型  
    /// 例子：如regValueKind 是DWord，则返回RegistryValueKind.DWord  
    /// </summary>  
    /// <param name="regValueKind">注册表数据类型</param>  
    /// <returns>注册表中对应的数据类型</returns>  
    protected RegistryValueKind GetRegValueKind(RegValueKind regValueKind)
    {
        RegistryValueKind regValueK;

        #region 判断注册表数据类型  

        switch (regValueKind)
        {
            case RegValueKind.Unknown:
                regValueK = RegistryValueKind.Unknown; break;
            case RegValueKind.String:
                regValueK = RegistryValueKind.String; break;
            case RegValueKind.ExpandString:
                regValueK = RegistryValueKind.ExpandString; break;
            case RegValueKind.Binary:
                regValueK = RegistryValueKind.Binary; break;
            case RegValueKind.DWord:
                regValueK = RegistryValueKind.DWord; break;
            case RegValueKind.MultiString:
                regValueK = RegistryValueKind.MultiString; break;
            case RegValueKind.QWord:
                regValueK = RegistryValueKind.QWord; break;
            default:
                regValueK = RegistryValueKind.String; break;
        }

        #endregion

        return regValueK;
    }

    #region 打开注册表项  

    /// <summary>  
    /// 打开注册表项节点，以只读方式检索子项  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <returns>如果SubKey为空、null或者SubKey指示注册表项不存在，则返回null，否则返回注册表节点</returns>  
    protected virtual RegistryKey OpenSubKey()
    {
        ///判断注册表项名称是否为空  
        if (_subkey == string.Empty || _subkey == null)
        {
            return null;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        ///要打开的注册表项的节点  
        RegistryKey sKey = null;
        ///打开注册表项  
        sKey = key.OpenSubKey(_subkey);
        ///关闭对注册表项的更改  
        key.Close();
        ///返回注册表节点  
        return sKey;
    }

    /// <summary>  
    /// 打开注册表项节点  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="writable">如果需要项的写访问权限，则设置为 true</param>  
    /// <returns>如果SubKey为空、null或者SubKey指示注册表项不存在，则返回null，否则返回注册表节点</returns>  
    protected virtual RegistryKey OpenSubKey(bool writable)
    {
        ///判断注册表项名称是否为空  
        if (_subkey == string.Empty || _subkey == null)
        {
            return null;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        ///要打开的注册表项的节点  
        RegistryKey sKey = null;
        ///打开注册表项  
        sKey = key.OpenSubKey(_subkey, writable);
        ///关闭对注册表项的更改  
        key.Close();
        ///返回注册表节点  
        return sKey;
    }

    /// <summary>  
    /// 打开注册表项节点，以只读方式检索子项  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <returns>如果SubKey为空、null或者SubKey指示注册表项不存在，则返回null，否则返回注册表节点</returns>  
    protected virtual RegistryKey OpenSubKey(string subKey)
    {
        ///判断注册表项名称是否为空  
        if (subKey == string.Empty || subKey == null)
        {
            return null;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        ///要打开的注册表项的节点  
        RegistryKey sKey = null;
        ///打开注册表项  
        sKey = key.OpenSubKey(subKey);
        ///关闭对注册表项的更改  
        key.Close();
        ///返回注册表节点  
        return sKey;
    }

    /// <summary>  
    /// 打开注册表项节点，以只读方式检索子项  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="writable">如果需要项的写访问权限，则设置为 true</param>  
    /// <returns>如果SubKey为空、null或者SubKey指示注册表项不存在，则返回null，否则返回注册表节点</returns>  
    protected virtual RegistryKey OpenSubKey(string subKey, bool writable)
    {
        ///判断注册表项名称是否为空  
        if (subKey == string.Empty || subKey == null)
        {
            return null;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(_domain);

        ///要打开的注册表项的节点  
        RegistryKey sKey = null;
        ///打开注册表项  
        sKey = key.OpenSubKey(subKey, writable);
        ///关闭对注册表项的更改  
        key.Close();
        ///返回注册表节点  
        return sKey;
    }

    /// <summary>  
    /// 打开注册表项节点，以只读方式检索子项  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <returns>如果SubKey为空、null或者SubKey指示注册表项不存在，则返回null，否则返回注册表节点</returns>  
    protected virtual RegistryKey OpenSubKey(string subKey, RegDomain regDomain)
    {
        ///判断注册表项名称是否为空  
        if (subKey == string.Empty || subKey == null)
        {
            return null;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(regDomain);

        ///要打开的注册表项的节点  
        RegistryKey sKey = null;
        ///打开注册表项  
        sKey = key.OpenSubKey(subKey);
        ///关闭对注册表项的更改  
        key.Close();
        ///返回注册表节点  
        return sKey;
    }

    /// <summary>  
    /// 打开注册表项节点  
    /// 虚方法，子类可进行重写  
    /// </summary>  
    /// <param name="subKey">注册表项名称</param>  
    /// <param name="regDomain">注册表基项域</param>  
    /// <param name="writable">如果需要项的写访问权限，则设置为 true</param>  
    /// <returns>如果SubKey为空、null或者SubKey指示注册表项不存在，则返回null，否则返回注册表节点</returns>  
    protected virtual RegistryKey OpenSubKey(string subKey, RegDomain regDomain, bool writable)
    {
        ///判断注册表项名称是否为空  
        if (subKey == string.Empty || subKey == null)
        {
            return null;
        }

        ///创建基于注册表基项的节点  
        RegistryKey key = GetRegDomain(regDomain);

        ///要打开的注册表项的节点  
        RegistryKey sKey = null;
        ///打开注册表项  
        sKey = key.OpenSubKey(subKey, writable);
        ///关闭对注册表项的更改  
        key.Close();
        ///返回注册表节点  
        return sKey;
    }

    #endregion

    #endregion
}
