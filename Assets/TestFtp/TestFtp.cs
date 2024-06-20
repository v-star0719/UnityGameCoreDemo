using System.Collections;
using System.Collections.Generic;
using Kernel.Core;
using UnityEngine;
using UnityEngine.UI;

public class TestFtp : MonoBehaviour
{
    public InputField urlInput;
    public InputField userNameInput;
    public InputField passwordInput;
    public InputField filePathInput;
    public InputField textInput;
    public Text logText;

    private FtpData data;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnUploadStringSyncBtnClick()
    {
        var rt = FtpUtils.FtpUploadString(urlInput.text, userNameInput.text, passwordInput.text, textInput.text);
        logText.text = "UploadStringSync: " + rt;
    }

    public void OnUploadStringAsyncBtnClick()
    {
        if(data != null)
        {
            logText.text = "working";
            return;
        }
        data = FtpUtils.FtpUploadStringAsync(urlInput.text, userNameInput.text, passwordInput.text, textInput.text, () => logText.text = "UploadStringAsync OnFinish");
        logText.text = "UploadStringAsync start";
    }

    public void OnUploadFileAsyncBtnClick()
    {
        if(data != null)
        {
            logText.text = "working";
            return;
        }
        data = FtpUtils.FtpUploadFileAsync(urlInput.text, userNameInput.text, passwordInput.text, filePathInput.text, () => logText.text = "UploadFileAsync OnFinish");
        logText.text = "UploadFileAsync start";
    }

    public void OnDownloadStringSyncBtnClick()
    {
        var rt = FtpUtils.FtpDownloadString(urlInput.text, userNameInput.text, passwordInput.text);
        logText.text = "DownloadStringSync: " + (rt ?? "null");
    }

    public void OnDownloadStringAsyncBtnClick()
    {
        if(data != null)
        {
            logText.text = "working";
            return;
        }
        data = FtpUtils.FtpDownloadStringAsync(urlInput.text, userNameInput.text, passwordInput.text, () => logText.text = "DownloadStringAsync OnFinish");
        logText.text = "DownloadStringAsync start";
    }


    public void OnDownloadFileAsyncBtnClick()
    {
        if(data != null)
        {
            logText.text = "working";
            return;
        }
        data = FtpUtils.FtpDownloadFileAsync(urlInput.text, userNameInput.text, passwordInput.text, filePathInput.text, () => logText.text = "DownloadFileAsync OnFinish");
        logText.text = "DownloadFileAsync start";
    }

    public void OnMakeDirBtnClick()
    {
        var rt = FtpUtils.FtpMakeDir(urlInput.text, userNameInput.text, passwordInput.text);
        logText.text = "MakeDir: " + rt;
    }

    public void OnGetFileSizeBtnClick()
    {
        var rt = FtpUtils.FtpGetFileSize(urlInput.text, userNameInput.text, passwordInput.text);
        logText.text = "GetFileSize start";
    }

    public void OnStopBtnClick()
    {
        if(data != null)
        {
            FtpUtils.FtpStopThread(data);
            logText.text = "StopThread";
            data = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (data != null)
        {
            if (data.isFinished)
            {
                Debug.Log($"work finished. success: {data.success}. downloadText:{data.DownloadText}");
                data = null;
            }
        }
    }
}
