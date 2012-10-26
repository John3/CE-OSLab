//-----------------------------------------------------------------------------
// Copyright (c) 2012 Lukas Joergensen, FuzzyVoid Studio
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

datablock GraphEmitterNodeData(g_downSpiralNode : g_DefaultNode)
{
   xFunc = "cos(t/50)*t*0.02";
   yFunc = "sin(t/50)*t*0.02";
   zFunc = "t/20";
   Reverse = true;
   Loop = false;
};

function g_downSpiralNode::onBoundaryLimit(%this, %node, %Max)
{
   if(%Max)
      %node.Reverse = true;
   else
      %node.Reverse = false;
}

datablock GraphEmitterNodeData(flameSpiralSpellNode : g_downSpiralNode){ timeScale = 2;};
datablock GraphEmitterNodeData(spellWave : g_wavesNode){ Loop = false; };

function flameSpiralSpellNode::onBoundaryLimit(%this, %node, %Max)
{
   if(!%Max)
   {
      %node.setDatablock(spellWave);
   }
}

function spellWave::onBoundaryLimit(%this, %node, %Max)
{
   if(%Max)
   {
      %node.delete();
   }
}