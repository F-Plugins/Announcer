using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Announcer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using DotNet.Globbing.Evaluation;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;
using System.Linq;
using OpenMod.Core.Helpers;
using SDG.Unturned;

[assembly: PluginMetadata("F.Announcer", DisplayName = "Announcer")]
namespace Announcer
{
    public class Announcer : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_Configuration;
        private readonly ILogger<Announcer> m_Logger;

        private bool _SendMessage = false;
        private int _Message = 0;

        public Announcer(
            IConfiguration configuration,
            ILogger<Announcer> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Configuration = configuration;
            m_Logger = logger;
        }

        protected override UniTask OnLoadAsync()
        {
            _SendMessage = true;
            if (Level.isLoaded)
            {
                AsyncHelper.Schedule("Announcement Start", () => Announcement().AsTask());
            }
            Level.onLevelLoaded += OnLevelLoaded;
            m_Logger.LogInformation("Announcer Plugin Loaded Correctly !");
            return UniTask.CompletedTask;
        }

        protected override UniTask OnUnloadAsync()
        {
            _SendMessage = false;
            m_Logger.LogInformation("Announcer Plugin Unloaded Correctly !"); 
            return UniTask.CompletedTask;
        }

        private void OnLevelLoaded(int level)
        {
            if (level == 2)
            {
                AsyncHelper.Schedule("Announcement Start", () => Announcement().AsTask());
            }
        }

        private async UniTask Announcement()
        {
            await UniTask.SwitchToMainThread();
            while (_SendMessage)
            {
                await Task.Delay(TimeSpan.FromSeconds(m_Configuration.GetSection("Timer").Get<int>()));
                var announces = m_Configuration.GetSection("Announces").Get<List<Announce>>();

                if (_Message >= announces.Count())
                {
                    _Message = 0;
                }

                var selected = announces[_Message];
                if (selected.Message != null)
                {
                    ChatManager.serverSendMessage(selected.Message.Replace("{", "<").Replace("}", ">"), UnityEngine.Color.white, null, null, EChatMode.GLOBAL, selected.Url, selected.IsRich);
                }

                _Message++;
            }
        }
    }
}
