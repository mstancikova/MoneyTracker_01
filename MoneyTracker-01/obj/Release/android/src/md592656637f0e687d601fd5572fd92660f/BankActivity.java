package md592656637f0e687d601fd5572fd92660f;


public class BankActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MoneyTracker_01.BankActivity, MoneyTracker-01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BankActivity.class, __md_methods);
	}


	public BankActivity ()
	{
		super ();
		if (getClass () == BankActivity.class)
			mono.android.TypeManager.Activate ("MoneyTracker_01.BankActivity, MoneyTracker-01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
