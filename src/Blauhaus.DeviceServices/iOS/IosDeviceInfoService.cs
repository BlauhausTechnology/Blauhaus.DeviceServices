using System;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Security;
using Foundation;

namespace Blauhaus.DeviceServices.Platforms.iOS
{
    public class IosDeviceInfoService : BaseDeviceInfoService
    {
        private string? _deviceId;

        public override string DeviceUniqueIdentifier
        {
            get
            {
                if (_deviceId == null)
                {
                    var idRecord = new SecRecord(SecKind.GenericPassword) {Generic = NSData.FromString("deviceId")};
                    var matchingIdRecord = SecKeyChain.QueryAsRecord(idRecord, out  var idResult);
                    if (idResult == SecStatusCode.Success)
                    {
                        _deviceId = matchingIdRecord.ValueData.ToString();
                    }
                    else
                    {
                        
                        Xamarin.Essentials.SecureStorage.DefaultAccessible = SecAccessible.AlwaysThisDeviceOnly;

                        _deviceId = Guid.NewGuid().ToString();

                        var newIdRecord = new SecRecord(SecKind.GenericPassword)
                        {
                            ValueData = NSData.FromString(_deviceId),
                            Synchronizable = false,
                            Generic = NSData.FromString("deviceId")
                        };

                        var saveResponse = SecKeyChain.Add(newIdRecord);

                        if (saveResponse != SecStatusCode.Success && saveResponse != SecStatusCode.DuplicateItem)
                        {
                            _deviceId = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
                        }
                    }
                }
                return _deviceId;
            }
        }
    }
}