﻿using ReClassNET.Nodes;

namespace ReClassNET.DataExchange.ReClass.Legacy
{
	public class ClassPointerArrayNode : ClassArrayNode
	{
		public override bool PerformCycleCheck => false;

		public override BaseNode GetEquivalentNode(int count, ClassNode classNode)
		{
			var classInstanceNode = new ClassInstanceNode();
			classInstanceNode.CanChangeInnerNodeTo(classNode);

			var pointerNode = new PointerNode();
			pointerNode.ChangeInnerNode(classInstanceNode);

			var arrayNode = new ArrayNode { Count = count };
			arrayNode.ChangeInnerNode(pointerNode);

			return arrayNode;
		}
	}
}