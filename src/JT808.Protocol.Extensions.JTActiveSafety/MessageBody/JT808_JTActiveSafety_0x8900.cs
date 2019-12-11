﻿using JT808.Protocol.Formatters;
using JT808.Protocol.MessageBody;
using JT808.Protocol.MessagePack;
using System.Collections.Generic;

namespace JT808.Protocol.Extensions.JTActiveSafety.MessageBody
{
    /// <summary>
    /// 查询基本信息
    /// </summary>
    public class JT808_JTActiveSafety_0x8900: JT808_0x8900_BodyBase, IJT808MessagePackFormatter<JT808_JTActiveSafety_0x8900>
    {
        /// <summary>
        /// 外设ID列表总数
        /// </summary>
        public byte USBCount { get; set; }
        /// <summary>
        /// 外设ID
        /// </summary>
        public List<byte> MultipleUSB { get; set; }

        public JT808_JTActiveSafety_0x8900 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_JTActiveSafety_0x8900 jT808_JTActiveSafety_0X8900 = new JT808_JTActiveSafety_0x8900();
            jT808_JTActiveSafety_0X8900.USBCount = reader.ReadByte();
            if (jT808_JTActiveSafety_0X8900.USBCount > 0)
            {
                jT808_JTActiveSafety_0X8900.MultipleUSB = new List<byte>();
                for (int i = 0; i < jT808_JTActiveSafety_0X8900.USBCount; i++)
                {
                    jT808_JTActiveSafety_0X8900.MultipleUSB.Add(reader.ReadByte());
                }
            }
            return jT808_JTActiveSafety_0X8900;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_JTActiveSafety_0x8900 value, IJT808Config config)
        {
            if (value.MultipleUSB != null && value.MultipleUSB.Count > 0)
            {
                writer.WriteByte((byte)value.MultipleUSB.Count);
                foreach (var item in value.MultipleUSB)
                {
                    writer.WriteByte(item);
                }
            }
        }
    }
}
