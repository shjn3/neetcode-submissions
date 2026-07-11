/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {    
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(subRoot==null) return true;
        if(root==null) return false;
        if(root.val==subRoot.val){
           bool ans=  IsTheSame(root,subRoot);
           if(ans) return ans;
        }

        bool isSubLeft = IsSubtree(root.left,subRoot);
        if(isSubLeft) return true;
        bool isSubRight = IsSubtree(root.right,subRoot);
        return isSubRight;
    }

    public bool IsTheSame(TreeNode root, TreeNode root2){
        if(root==null && root2==null) return true;
        if(root==null || root2==null || root.val!=root2.val) return false;

        bool isSameLeft = IsTheSame(root.left,root2.left);
        if(!isSameLeft) return false;
        bool isSameRight = IsTheSame(root.right,root2.right);
        return isSameRight;
    }
}
